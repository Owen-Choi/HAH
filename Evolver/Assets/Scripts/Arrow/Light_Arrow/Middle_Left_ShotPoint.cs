using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle_Left_ShotPoint : MonoBehaviour
{
    public GameObject arrow;
    Vector3 shootDirection;
    public float offset; bool Zero_Stamina; float EverySecond = 0f; float HoldingTime = 0f;
    float launchForce; float increaseDamage; float increaseLaunchForce; bool ischanged;    float ChargingDamage;    float TempDMG;  float TempLF;
    private void Start()
    {
        ChargingDamage = Player_Stat.instance.Charge_Damage_Plus;
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

            if (Player_Stat.instance.stamina < 0 && !Zero_Stamina && HoldingTime > 0.4f)
            {
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
                increaseDamage += ChargingDamage;
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


        float degree = Mathf.Atan2(difference.y, difference.x) + 0.2f;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;                   
        shootDirection.x = (float)2f * Mathf.Cos(degree);                       
        shootDirection.y = (float)2f * Mathf.Sin(degree);

        

        GameObject newArrow = Instantiate(arrow, transform.position, this.transform.rotation);
        newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = increaseDamage;
        newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = increaseLaunchForce;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (launchForce + increaseLaunchForce),
           shootDirection.y * (launchForce + increaseLaunchForce));
       
    }


    public void Shoot(float tempDamage, float tempLaunchForce)
    {
        
        shootDirection = Input.mousePosition;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();                 


        float degree = Mathf.Atan2(difference.y, difference.x) + 0.2f;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;                  
        shootDirection.x = (float)2f * Mathf.Cos(degree);                       
        shootDirection.y = (float)2f * Mathf.Sin(degree);

        
        
        GameObject newArrow = Instantiate(arrow, transform.position, this.transform.rotation);
        newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = tempDamage;
        newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = increaseLaunchForce;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (launchForce + tempLaunchForce),
           shootDirection.y * (launchForce + tempLaunchForce));
        
    }


  
}
