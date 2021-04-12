using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie_Stat : MonoBehaviour
{
    public bool is_burned;
    public float Health;
    public float Power = 10f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")                     //불화살의 경우는 Fire_Arrow의 스크립트에서 확률적으로 화상 상태로 레이어를 변경한다.
        {
            if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit)              //AbsolCrit는 100%의 확률로 크리티컬 히트를 제공한다.
            {
                if (Player_Stat.instance.AbsolCrit)
                {
                    Player_Stat.instance.AbsolCrit = false;
                }
                Health -= ((Player_Stat.instance.damage + other.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
                CameraShake.instance.cameraShake();
            }
            else
                Health -= (Player_Stat.instance.damage + other.GetComponent<Arrow_Damage_System>().HoldDamage);
        }
    }
    private void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);

        if(this.gameObject.layer == LayerMask.NameToLayer("Servant_Burned"))
        {
            is_burned = true;                                                       //this line makes Burning Animation Start by Changing its value
            StartCoroutine("Burning_Time");
        }
    }

    IEnumerator Burning_Time()
    {
        yield return new WaitForSeconds(5f);
        is_burned = false;
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");                   //may cause some errors. if there are not only Enemy layers, this code should be changed 
    }
}
