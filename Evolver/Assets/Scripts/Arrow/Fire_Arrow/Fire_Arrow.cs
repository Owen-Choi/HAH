using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow : MonoBehaviour
{
    public bool isSoot;                             //그을림 스킬체크 변수
    public float countTime;
    EdgeCollider2D EdgeCol;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
            //치명타 적용시
            if(Random.Range(0, 100) < Player_Stat.instance.criticalPercent)
            {
                other.GetComponent<Zombie_Stat>().Health -= ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
                CameraShake.instance.cameraShake();
            }
            //치명타 미적용시
            else
                other.GetComponent<Zombie_Stat>().Health -= (Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage);


            if (Random.Range(0, 100) < Player_Stat.instance.Burn_Percent)
            {
                if(isSoot)
                    other.gameObject.layer = LayerMask.NameToLayer("Master_Burned");                //그을림 스킬체크 시 화상이 전염되는 Master_Burned 레이어로 바꿈 
                else
                    other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
            }
            StartCoroutine("DestroyDelay");
        }
        if (other.tag == "border")
            StartCoroutine("DestroyDelay");
    }

   IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
