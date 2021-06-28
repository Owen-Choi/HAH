using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShotPoint : MonoBehaviour
{
    public GameObject CritArrow;
    public GameObject arrow;
    public GameObject HoamingArrow;
    Vector3 shootDirection;
    public float offset;    bool Zero_Stamina;  float EverySecond = 0f;  float HoldingTime = 0f;    public bool isShoot;        float time = 0f; //WindStep을 위한 변수   
    float increaseDamage;   float increaseLaunchForce;  bool ischanged; public float degree;    float TempDMG;  float TempLF;
    public GameObject Middle_Left_ShotPoint;
    public GameObject Middle_Right_ShotPoint;
    public GameObject Full_Left_ShotPoint;
    public GameObject Full_Right_ShotPoint;
    public GameObject LightArrowUI;
    GameObject LightArrowUI_Cache;
    Color activate; Color deActivate;
    float DMGCache;

    
    public bool tester;
    private void Awake()
    {
        LightArrowUI_Cache = LightArrowUI;
        activate.r = 255;   activate.g = 255;   activate.b = 255;   activate.a = 255;
        deActivate.r = 255; deActivate.g = 255; deActivate.b = 255; deActivate.a = 0.3f;
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Input.GetMouseButton(0))
        {
            EverySecond += Time.deltaTime * Player_Stat.instance.ChargingSpeed;             // 신체부위 팔 스킬 중 차징속도 감소 스킬을 위한 코드. 아직 모든 ShotPoint에 적용된 것은 아니다.
            HoldingTime += Time.deltaTime * Player_Stat.instance.ChargingSpeed;

            Player_Stat.instance.stamina -= (3f * Player_Stat.instance.Decrease_Stamina_When_Bow_Charge) * Time.deltaTime;
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
                increaseDamage += 6;
            }

            if ((int)EverySecond >= 1)  //매 초마다 차징 수준을 올려주기 위한 장치. Coroutine을 이용한 방법이 왜인지 동작을 하지 않아 이렇게 바꾸었다.
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
                if (Player_Stat.instance.is_Continued_Shot && !Player_Stat.instance.is_Continued_Shot2)
                {
                    TempDMG = increaseDamage;
                    TempLF = increaseLaunchForce;
                    StartCoroutine("ShootDelay");
                }
                else if (Player_Stat.instance.is_Continued_Shot && Player_Stat.instance.is_Continued_Shot2)
                {
                    TempDMG = increaseDamage;
                    TempLF = increaseLaunchForce;
                    StartCoroutine("DoubleShootDelay");
                }
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
            LightArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = activate;
        }
        else if(HoldingTime > 2f && HoldingTime < 3f)
        {
            LightArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = activate;
            LightArrowUI_Cache.transform.GetChild(1).GetComponent<Image>().color = activate;
        }
        else if(HoldingTime > 3f)
        {
            LightArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = activate;
            LightArrowUI_Cache.transform.GetChild(1).GetComponent<Image>().color = activate;
            LightArrowUI_Cache.transform.GetChild(2).GetComponent<Image>().color = activate;
        }

        if(isShoot)
        {
            time += Time.deltaTime;
            if(time > 0.5f)
            {
                time = 0;
                isShoot = false;
            }
        }

    }


    public void Shoot()
    {
        LightArrowUI_Cache.transform.GetChild(0).GetComponent<Image>().color = deActivate;              //활을 쏘면 차징 UI 초기화
        LightArrowUI_Cache.transform.GetChild(1).GetComponent<Image>().color = deActivate;
        LightArrowUI_Cache.transform.GetChild(2).GetComponent<Image>().color = deActivate;

        shootDirection = Input.mousePosition;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();                 

        float degree = Mathf.Atan2(difference.y, difference.x);                 
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;                   
        shootDirection.x = (float)2f * Mathf.Cos(degree);                       
        shootDirection.y = (float)2f * Mathf.Sin(degree);

        //shootDirection = shootDirection - transform.position;                

        if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit || Player_Stat.instance.Runner)
        {
            if (Player_Stat.instance.Runner)
            {
                Player_Stat.instance.Runner = false;                    //Runner로 얻는 치명타는 연속사격에는 적용되지 않는다.
            }
            GameObject newArrow = Instantiate(CritArrow, transform.position, this.transform.rotation);
            newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = increaseDamage;
            newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = increaseLaunchForce;
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (Player_Stat.instance.launchForce + increaseLaunchForce),
               shootDirection.y * (Player_Stat.instance.launchForce + increaseLaunchForce));
            newArrow.GetComponent<LightArrow_For_Crit>().Launched = true;

            if (tester)
            {
                StartCoroutine("HoamingDelay");
                    //GameObject hoaming = Instantiate(HoamingArrow, transform.position, this.transform.rotation);
                    //hoaming.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y);
            }
        }

        else
        {
            GameObject newArrow = Instantiate(arrow, transform.position, this.transform.rotation);
            newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = increaseDamage;
            newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = increaseLaunchForce;
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (Player_Stat.instance.launchForce + increaseLaunchForce),
               shootDirection.y * (Player_Stat.instance.launchForce + increaseLaunchForce));
            newArrow.GetComponent<Arrow>().Launched = true;
        }
        isShoot = true;
        
    }

    public void Shoot(float tempDamage, float tempLaunchForce)
    {
        
        shootDirection = Input.mousePosition;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();                 //플레이어를 중심으로 하는 원에서 마우스 커서의 좌표를 구하기 위해(sin ,cos) 삼각형의 각이 필요하다. 그 각을 구하기 위한 변수


        float degree = Mathf.Atan2(difference.y, difference.x);
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;                   
        shootDirection.x = (float)2f * Mathf.Cos(degree);                       //각을 알았으면 화살의 속도가 커서의 위치에 관계 없이 일정한 속도로 나가게 하기 위해 각을 토대로 좌표를 정해버린다.
        shootDirection.y = (float)2f * Mathf.Sin(degree);

        //shootDirection = shootDirection - transform.position;                

        if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit)
        {
            GameObject newArrow = Instantiate(CritArrow, transform.position, this.transform.rotation);
            newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = tempDamage;
            newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = tempLaunchForce;
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (Player_Stat.instance.launchForce + tempLaunchForce),
               shootDirection.y * (Player_Stat.instance.launchForce + tempLaunchForce));
            newArrow.GetComponent<LightArrow_For_Crit>().Launched = true;
        }

        else
        {
            GameObject newArrow = Instantiate(arrow, transform.position, this.transform.rotation);
            newArrow.GetComponent<Arrow_Damage_System>().HoldDamage = tempDamage;
            newArrow.GetComponent<Arrow_Damage_System>().HoldLaunchForce = tempLaunchForce;
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (Player_Stat.instance.launchForce + tempLaunchForce),
               shootDirection.y * (Player_Stat.instance.launchForce + tempLaunchForce));
            newArrow.GetComponent<Arrow>().Launched = true;
        }
        isShoot = true;
        
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.35f);
        this.Shoot(TempDMG, TempLF);
        if (Middle_Left_ShotPoint.gameObject.activeSelf)
        {
            Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(TempDMG, TempLF);
            Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(TempDMG, TempLF);
            if (Full_Left_ShotPoint.gameObject.activeSelf)
            {
                Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(TempDMG, TempLF);
                Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(TempDMG, TempLF);
            }
        }
        TempDMG = 0; TempLF = 0;
    }

    IEnumerator DoubleShootDelay()
    {
        yield return new WaitForSeconds(0.35f);
        this.Shoot(TempDMG, TempLF);
        if (Middle_Left_ShotPoint.gameObject.activeSelf)
        {
            Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(TempDMG, TempLF);
            Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(TempDMG, TempLF);
            if (Full_Left_ShotPoint.gameObject.activeSelf)
            {
                Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(TempDMG, TempLF);
                Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(TempDMG, TempLF);
            }
        }
        yield return new WaitForSeconds(0.35f);
        this.Shoot(TempDMG, TempLF);
        if (Middle_Left_ShotPoint.gameObject.activeSelf)
        {
            Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(TempDMG, TempLF);
            Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(TempDMG, TempLF);
            if (Full_Left_ShotPoint.gameObject.activeSelf)
            {
                Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(TempDMG, TempLF);
                Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(TempDMG, TempLF);
            }
        }
        TempDMG = 0; TempLF = 0;
    }


    public void RobinHood()
    {
        DMGCache = Player_Stat.instance.damage;
        this.Shoot(DMGCache, 10);
        if (Middle_Left_ShotPoint.gameObject.activeSelf)
        {
            Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(DMGCache, 10);
            Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(DMGCache, 10);
            if (Full_Left_ShotPoint.gameObject.activeSelf)
            {
                Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(DMGCache, 10);
                Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(DMGCache, 10);
            }
        }
    }

    IEnumerator HoamingDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject hoaming = Instantiate(HoamingArrow, transform.position, this.transform.rotation);
        hoaming.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y);
    }
}
