using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Hoaming_Arrow : MonoBehaviour
{
    EdgeCollider2D EdgeCol;
    public bool Launched; float time;
    float DMG;  int layerMask;  float radius = 10f;
    Vector3 vec;    GameObject temp;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
        layerMask = (1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("EnemyChasing") | (1 << LayerMask.NameToLayer("Servant_Burned")) | 1 << LayerMask.NameToLayer("Enemy_Bug"));
    }


    private void Update()
    {
        if (Launched)
        {
            time += Time.deltaTime;
            if (time > 3.5f)
                Destroy(this.gameObject);
        }
        
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, layerMask);
        if (circle)
        {
            this.GetComponent<AIDestinationSetter>().target = circle.transform;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
            EdgeCol.isTrigger = false;
            //경량화살의 경우 격발 시점에서 크리티컬이 결정되어 화살의 오브젝트가 바뀐다. 크리티컬 화살의 경우 반드시 치명타로 적용된다.
            if (Player_Stat.instance.AbsolCrit)
            {
                Player_Stat.instance.AbsolCrit = false;         //역마살 스킬체크로 인한 치명타일 경우 
            }
            DMG = Player_Stat.instance.damage * 1.5f;           //유도화살의 공격력은 플레이어 공격력의 1.5배
            other.GetComponent<Zombie_Stat>().Health -= DMG;
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();
            Destroy(this.gameObject);

        }
       
    }

    
}
