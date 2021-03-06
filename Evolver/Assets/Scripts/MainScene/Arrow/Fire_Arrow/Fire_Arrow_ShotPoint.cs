using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fire_Arrow_ShotPoint : MonoBehaviour
{
    public GameObject Fire_Arrow_For_Explode;
    public GameObject Fire_Arrow;
    Vector3 shootDirection;
    public float offset; bool Zero_Stamina; float EverySecond = 0f; float HoldingTime = 0f;
    float launchForce; float increaseDamage; float increaseLaunchForce; bool ischanged; float chargingDamage; float TempDMG; float TempLF;
    public bool is_Explode; public bool isShoot;
    public GameObject FireArrowUI;
    GameObject FireArrowUI_Cache; Color activate; Color DeActivate;
    private void Start()
    {
        chargingDamage = Player_Stat.instance.Charge_Damage_Plus;
        launchForce = Player_Stat.instance.launchForce;
        FireArrowUI_Cache = FireArrowUI;
        activate.r = 255; activate.g = 255; activate.b = 255; activate.a = 255;
        DeActivate.r = 255; DeActivate.g = 255; DeActivate.b = 255; DeActivate.a = 0.3f;
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Input.GetMouseButton(0))
        {
            EverySecond += Time.deltaTime * Player_Stat.instance.ChargingSpeed;
            HoldingTime += Time.deltaTime * Player_Stat.instance.ChargingSpeed;

            Player_Stat.instance.stamina -= (3.5f * Player_Stat.instance.Decrease_Stamina_When_Bow_Charge) * Time.deltaTime;
            if (Player_Stat.instance.stamina < 0 && !Zero_Stamina && HoldingTime > 0.4f)
            {
                if (is_Explode && Random.Range(0,100) < Player_Stat.instance.criticalPercent || is_Explode && Player_Stat.instance.AbsolCrit)     //폭발화살 구현 코드
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
                if (is_Explode && Random.Range(0, 100) < Player_Stat.instance.criticalPercent || is_Explode && Player_Stat.instance.AbsolCrit)      //폭발화살 구현 코드
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

        if (HoldingTime > 1f && HoldingTime < 2f)
        {
            FireArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = activate;
        }
        else if (HoldingTime > 2f && HoldingTime < 3f)
        {
            FireArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = activate;
            FireArrowUI_Cache.transform.GetChild(1).GetComponent<Image>().color = activate;
        }
        else if (HoldingTime > 3f)
        {
            FireArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = activate;
            FireArrowUI_Cache.transform.GetChild(1).GetComponent<Image>().color = activate;
            FireArrowUI_Cache.transform.GetChild(2).GetComponent<Image>().color = activate;
        }

        if (isShoot)
        {
            FireArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = DeActivate;
            FireArrowUI_Cache.transform.GetChild(1).GetComponent<Image>().color = DeActivate;
            FireArrowUI_Cache.transform.GetChild(2).GetComponent<Image>().color = DeActivate;
            isShoot = false;
        }

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
        newArrow.GetComponent<Fire_Arrow>().Launched = true;
        isShoot = true;                         //심지 준비 관련 변수. 다시 false로 변경도 심지 준비 스크립트에서 해준다.  추후 변경 가능
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
        newArrow.GetComponent<Fire_Arrow_For_Explode>().Launched = true;
        isShoot = true;
    }
   
}
