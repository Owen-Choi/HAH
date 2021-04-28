using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie_Stat : MonoBehaviour
{
    bool isOnce;
    Rigidbody2D rigid;
    int i;   int CurrentFireborne;
    public bool is_burned;  public float Burning_DMG;     //스킬 관련 변수들
    public float Health;
    public float Power = 10f;
    private void Start()
    {
        CurrentFireborne = 0;
        rigid = GetComponent<Rigidbody2D>();
    }

   /* void OnTriggerEnter2D(Collider2D other)
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
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && this.gameObject.layer == LayerMask.NameToLayer("Master_Burned") && CurrentFireborne <= Player_Stat.instance.FireborneMax)
        {
            collision.gameObject.layer = LayerMask.NameToLayer("Master_Burned");
            CurrentFireborne++;
        }
    }

    private void Update()
    {
        Burning_DMG = Player_Stat.instance.Burning_DMG;

        if (Health <= 0)
            Destroy(gameObject);

        //화상 레이어에서 해당 조건문을 계속 체크해서 무조건 즉사되는 버그 발생, isOnce 변수 추가해서 조치
        if(this.gameObject.layer == LayerMask.NameToLayer("Servant_Burned") || this.gameObject.layer == LayerMask.NameToLayer("Master_Burned")) //서번트, 혹은 마스터 상태의 화상인지 체크
        {
            if (Player_Stat.instance.isPyro && Random.Range(0, 100) <= 2 && !isOnce)
            {
                CameraShake.instance.cameraShake();
                Destroy(this.gameObject);
                isOnce = false; 
            }
            else
            {
                isOnce = true;
                is_burned = true;                                                       //this line makes Burning Animation Start by Changing its value
                StartCoroutine("Burning_Time");
            }
        }

    }

    IEnumerator Burning_Time()
    {
        yield return StartCoroutine("Burning_Damage_Delay");
        is_burned = false;
        CurrentFireborne = 0;                                                     //그을림 관련 변수를 0으로 초기화해서 다시 전염이 가능하도록 만들어주기
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");                   //may cause some errors. if there are not only Enemy layers, this code should be changed 
    }

    IEnumerator Burning_Damage_Delay()                                              //코루틴 딜레이 생각해보기
    {
        for (i = 0; i < 250; i++)                                                   //이게 맞나;; 수정할 여지가 많다
        {
            yield return new WaitForSeconds(0.25f);
            Health -= Burning_DMG;
        }
    }


    private void OnDestroy()
    {
        Instantiate(Resources.Load("Zombie_Dead"), this.transform.position, this.transform.rotation);

        if(Random.Range(0,100) < GameObject.Find("BackPack").GetComponent<BackPack>().GetDropPercent("MutantSample"))  //백팩 -> 인벤토리 순으로 접근
        {
            Instantiate(Resources.Load("MutantSample"), this.transform.position, this.transform.rotation);      //생성 위치에 변동을 주고싶다면 이 코드를 수정하자.
        }
    }

}
