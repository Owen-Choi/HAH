using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver_Arrow_ShotPoint : MonoBehaviour
{ 
    Vector3 shootDirection; public GameObject Silver_Arrow; 
    public float offset; bool Zero_Stamina; float EverySecond = 0f; float HoldingTime = 0f;
    float launchForce; public float increaseDamage; float increaseLaunchForce; bool ischanged; float chargingDamage; float TempDMG; float TempLF;  float MaxDist = 15f;
    TrailRenderer tr;  public float DMGPercent;  float First;    float Second;  float DSC;
    public bool concen; public bool Long_range;  public bool Penetrate;   //스킬 관련 변수들
    private void Start()
    {
        chargingDamage = Player_Stat.instance.Charge_Damage_Plus + 14;
        launchForce = Player_Stat.instance.launchForce;
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        DSC = Player_Stat.instance.Decrease_Stamina_When_Bow_Charge;
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Input.GetMouseButton(0))
        {
            if (Penetrate)
            {
                EverySecond += Time.deltaTime * 1.2f;
                HoldingTime += Time.deltaTime * 1.2f;
            }
            else
            {
                EverySecond += Time.deltaTime;
                HoldingTime += Time.deltaTime;
            }
            First = Player_Stat.instance.stamina;
            Player_Stat.instance.stamina -= (0.03f * DSC);
            if (Player_Stat.instance.stamina < 0 && !Zero_Stamina)
            {
                Second = Player_Stat.instance.stamina;
                if(concen)
                increaseDamage += (First - Second); 
                Shoot();
                increaseDamage = 0f;
                increaseLaunchForce = 0f;
                Zero_Stamina = true;
            }

            if (((int)HoldingTime % 1 == 0 && HoldingTime > 1f) && HoldingTime <= 3.5f && !ischanged)
            {
                ischanged = true;
                increaseLaunchForce += 3;
                increaseDamage += chargingDamage;
            }

            if ((int)EverySecond >= 1)
            {
                EverySecond = 0;
                ischanged = false;
            }
        }
        if (Input.GetMouseButtonUp(0) && !Zero_Stamina)
        {
            if (HoldingTime < 0.4f)
                Debug.Log("Blocked");
            else
            {
                Second = Player_Stat.instance.stamina;
                if (concen)
                    increaseDamage += (First - Second);
                Shoot();
                HoldingTime = 0f;
                EverySecond = 0f;
                increaseDamage = 0f;
                increaseLaunchForce = 0f;
            }
        }
        if (Zero_Stamina && !Input.GetMouseButton(0))
            Zero_Stamina = false;


        
    }


    public void Shoot()
    {
        shootDirection = Input.mousePosition;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();                 


        float degree = Mathf.Atan2(difference.y, difference.x);
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        shootDirection.x = (float)2f * Mathf.Cos(degree);                       
        shootDirection.y = (float)2f * Mathf.Sin(degree);

        GameObject new_Silver_Arrow = Instantiate(Silver_Arrow, transform.position, this.transform.rotation);
        new_Silver_Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (200f),
           shootDirection.y * (200f));
        RayAll();
    }

   void RayAll()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, shootDirection, MaxDist);
        DMGPercent = 10f;
        for (int i = 0; i<hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.transform.tag == "Enemy" && DMGPercent > 0f)
            {
                if (Long_range && hit.distance > 4f)                    //장거리 사격 스킬체크시 increaseDamage에 플레이어 스탯의 데미지를 더해준다.
                {
                    increaseDamage += Player_Stat.instance.damage;
                }
                hit.transform.GetComponent<Zombie_Stat>().Health -= increaseDamage * (float)(0.1f * DMGPercent);
                DMGPercent -= 1f;
            }
        }
    }

   
}
