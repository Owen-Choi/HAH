using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class CockRoach_AI : MonoBehaviour
{
    GameObject PlayerCache;
    Vector2 direction;
    GameObject BackPackCache;
    [SerializeField]
    float damage;
    float angle;    float offset;   float radius = 7f;
    void Start()
    {
        PlayerCache = GameObject.Find("Player");            //Find 함수로 플레이어를 찾은 뒤 캐싱.
        offset = 90f;
        BackPackCache = GameObject.Find("BackPack");
        this.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = null;
    }

    
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));        //Player가 일정 범위에 들어온다면 타겟으로 설정

        if (circle)
            this.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = PlayerCache.transform;

        if (this.transform.hasChanged)          //오브젝트가 움직인다면(플레이어를 쫓는다면)
        {
            this.gameObject.layer = LayerMask.NameToLayer("EnemyChasing");
            FaceTarget();
            this.transform.hasChanged = false;      //test
        }
           

    }

    void FaceTarget()
    {
        direction = PlayerCache.transform.position - this.transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Player_Stat.instance.armor > damage)
                Player_Stat.instance.health -= 2;
            else
                Player_Stat.instance.health -= damage - Player_Stat.instance.armor;
            Destroy(this.transform.parent.gameObject);             //부모를 파괴할 경우 자신도 파괴됨.
        }

        if (collision.tag == "PlayerAttack")
            Destroy(this.transform.parent.gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(Resources.Load("CockroachDead"), this.transform.position, Quaternion.identity);
        if (Random.Range(0, 100) <BackPackCache.GetComponent<BackPack>().GetDropPercent("MutantSample"))  //백팩 -> 인벤토리 순으로 접근
        {
            Instantiate(Resources.Load("MutantSample"), this.transform.position, Quaternion.identity);      //생성 위치에 변동을 주고싶다면 이 코드를 수정하자.
        }
    }

}
