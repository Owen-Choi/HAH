using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow : MonoBehaviour
{
    public bool isSoot;                             //������ ��ųüũ ����
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
            //ġ��Ÿ �����
            if(Random.Range(0, 100) < Player_Stat.instance.criticalPercent)
            {
                other.GetComponent<Zombie_Stat>().Health -= ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
                CameraShake.instance.cameraShake();
            }
            //ġ��Ÿ �������
            else
                other.GetComponent<Zombie_Stat>().Health -= (Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage);


            if (Random.Range(0, 100) < Player_Stat.instance.Burn_Percent)
            {
                if(isSoot)
                    other.gameObject.layer = LayerMask.NameToLayer("Master_Burned");                //������ ��ųüũ �� ȭ���� �����Ǵ� Master_Burned ���̾�� �ٲ� 
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
