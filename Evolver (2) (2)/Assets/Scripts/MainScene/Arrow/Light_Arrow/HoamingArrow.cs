using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class HoamingArrow : MonoBehaviour
{
    EdgeCollider2D EdgeCol;
    public bool Launched; float time;
    float radius = 12f;
    int layermask;
    bool forOnce;
    GameObject temp;
    float DMG;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
        layermask = (1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("Servant_Burned") | (1 << LayerMask.NameToLayer("Master_Burned")) | 1 << LayerMask.NameToLayer("EnemyChasing"));
    }


    private void Update()
    {
        if (Launched)
        {
            time += Time.deltaTime;
            if (time > 5f)
                Destroy(this.gameObject);
        }
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, layermask);
        if (circle)
        {
            this.GetComponent<AIDestinationSetter>().target = circle.transform;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
            if (Player_Stat.instance.AbsolCrit)
            {
                Player_Stat.instance.AbsolCrit = false;         //역마살 스킬체크로 인한 치명타일 경우 
            }
            Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
            DMG = ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
            other.GetComponent<Zombie_Stat>().Health -= DMG;
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();
            //CameraShake.instance.cameraShake();
            Destroy(this.gameObject);
        }
    }

   
}
