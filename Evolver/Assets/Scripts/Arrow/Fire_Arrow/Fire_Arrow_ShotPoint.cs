using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow_ShotPoint : MonoBehaviour
{
    public GameObject Fire_Arrow_For_Explode;
    public GameObject Fire_Arrow;
    Vector3 shootDirection;
    public float offset; bool Zero_Stamina; float EverySecond = 0f; float HoldingTime = 0f;
    float launchForce; float increaseDamage; float increaseLaunchForce; bool ischanged; float chargingDamage; float TempDMG; float TempLF;
    public bool is_Explode;
    private void Start()
    {
        chargingDamage = Player_Stat.instance.Charge_Damage_Plus;
        launchForce = Player_Stat.instance.launchForce;

    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Input.GetMouseButton(0))
        {
            EverySecond += Time.deltaTime;
            HoldingTime += Time.deltaTime;

            Player_Stat.instance.stamina -= (3.5f * Player_Stat.instance.Decrease_Stamina_When_Bow_Charge) * Time.deltaTime;
            if (Player_Stat.instance.stamina < 0 && !Zero_Stamina && HoldingTime > 0.4f)
            {
                if (is_Explode && Random.Range(0,100) < Player_Stat.instance.criticalPercent)                                    //폭발화살 구현 코드
                    Explode_Shoot();
                else
                    Shoot();
                HoldingTime = 0f;
                EverySecond = 0f;
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
                HoldingTime = 0f;
            else
            {
                if (is_Explode && Random.Range(0, 100) < Player_Stat.instance.criticalPercent)                                    //폭발화살 구현 코드
                    Explode_Shoot();
                else
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





        GameObject newArrow = Instantiate(Fire_Arrow, transform.position, this.transform.rotation);
        newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = increaseDamage;
        newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = increaseLaunchForce;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (launchForce + increaseLaunchForce),
           shootDirection.y * (launchForce + increaseLaunchForce));

    }
        
    public void Explode_Shoot()                 //폭발 화살용 함수
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


        


        GameObject newArrow = Instantiate(Fire_Arrow_For_Explode, transform.position, this.transform.rotation);
        newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = increaseDamage;
        newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = increaseLaunchForce;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (launchForce + increaseLaunchForce),
           shootDirection.y * (launchForce + increaseLaunchForce));
    }
   
}
