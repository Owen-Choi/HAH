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
        PlayerCache = GameObject.Find("Player");            //Find �Լ��� �÷��̾ ã�� �� ĳ��.
        offset = 90f;
        BackPackCache = GameObject.Find("BackPack");
        this.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = null;
    }

    
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));        //Player�� ���� ������ ���´ٸ� Ÿ������ ����

        if (circle)
            this.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = PlayerCache.transform;

        if (this.transform.hasChanged)          //������Ʈ�� �����δٸ�(�÷��̾ �Ѵ´ٸ�)
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
            Destroy(this.transform.parent.gameObject);             //�θ� �ı��� ��� �ڽŵ� �ı���.
        }

        if (collision.tag == "PlayerAttack")
            Destroy(this.transform.parent.gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(Resources.Load("CockroachDead"), this.transform.position, Quaternion.identity);
        if (Random.Range(0, 100) <BackPackCache.GetComponent<BackPack>().GetDropPercent("MutantSample"))  //���� -> �κ��丮 ������ ����
        {
            Instantiate(Resources.Load("MutantSample"), this.transform.position, Quaternion.identity);      //���� ��ġ�� ������ �ְ�ʹٸ� �� �ڵ带 ��������.
        }
    }

}
