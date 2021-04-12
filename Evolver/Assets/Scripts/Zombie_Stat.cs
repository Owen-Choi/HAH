using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie_Stat : MonoBehaviour
{
    int i;
    public bool is_burned;  public float Burning_DMG = 0.0005f;     //��ų ���� ������
    public float Health;
    public float Power = 10f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")                     //��ȭ���� ���� Fire_Arrow�� ��ũ��Ʈ���� Ȯ�������� ȭ�� ���·� ���̾ �����Ѵ�.
        {
            if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit)              //AbsolCrit�� 100%�� Ȯ���� ũ��Ƽ�� ��Ʈ�� �����Ѵ�.
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
            if (Player_Stat.instance.isPyro && Random.Range(0, 100) <= 2)
            {
                CameraShake.instance.cameraShake();
                Destroy(this.gameObject);
            }
            else
            {
                is_burned = true;                                                       //this line makes Burning Animation Start by Changing its value
                StartCoroutine("Burning_Time");
            }
        }
    }

    IEnumerator Burning_Time()
    {
        yield return StartCoroutine("Burning_Damage_Delay");
        is_burned = false;
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");                   //may cause some errors. if there are not only Enemy layers, this code should be changed 
    }

    IEnumerator Burning_Damage_Delay()                                              //�ڷ�ƾ ������ �����غ���
    {
        for (i = 0; i < 250; i++)                                                   //�̰� �³�;; ������ ������ ����
        {
            yield return new WaitForSeconds(0.25f);
            Health -= Burning_DMG;
        }
    }

}
