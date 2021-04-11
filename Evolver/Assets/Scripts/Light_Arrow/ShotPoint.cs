using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPoint : MonoBehaviour
{
    public GameObject arrow;
    Vector3 shootDirection;
    public float offset;    bool Zero_Stamina;  float EverySecond = 0f;  float HoldingTime = 0f;    public bool isShoot;        float time = 0f; //WindStep을 위한 변수   
    float launchForce;      float increaseDamage;   float increaseLaunchForce;  bool ischanged; public float degree;    float TempDMG;  float TempLF;
    public GameObject Middle_Left_ShotPoint;
    public GameObject Middle_Right_ShotPoint;
    public GameObject Full_Left_ShotPoint;
    public GameObject Full_Right_ShotPoint;

    private void Start()
    {
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

            Player_Stat.instance.stamina -= (0.03f * Player_Stat.instance.Decrease_Stamina_When_Bow_Charge);
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

            if ((int)EverySecond >= 1)
            {
                EverySecond = 0;
                ischanged = false;
            }
        }
        if (Input.GetMouseButtonUp(0) && !Zero_Stamina)
        {
            if (increaseLaunchForce == 0)
                ;
            else
            {
                Shoot();
                if (Player_Stat.instance.is_Continued_Shot && !Player_Stat.instance.is_Continued_Shot2)
                {
                    TempDMG = increaseDamage;
                    TempLF = increaseLaunchForce;
                    StartCoroutine("ShootDelay");
                }
                else if(Player_Stat.instance.is_Continued_Shot && Player_Stat.instance.is_Continued_Shot2)
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

        GameObject newArrow = Instantiate(arrow, transform.position, this.transform.rotation);
        newArrow.GetComponent<Arrow>().HoldDamage = increaseDamage;
        newArrow.GetComponent<Arrow>().HoldLaunchForce = increaseLaunchForce;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (launchForce + increaseLaunchForce),
           shootDirection.y * (launchForce + increaseLaunchForce));

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

        GameObject newArrow = Instantiate(arrow, transform.position, this.transform.rotation);
        newArrow.GetComponent<Arrow>().HoldDamage = tempDamage;
        newArrow.GetComponent<Arrow>().HoldLaunchForce = increaseLaunchForce;
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (launchForce + tempLaunchForce),
           shootDirection.y * (launchForce + tempLaunchForce));
        isShoot = true;
        
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.35f);
        this.Shoot(TempDMG, TempLF);
        Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(TempDMG, TempLF);
        Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(TempDMG, TempLF);
        if (Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().enabled)
        {
            Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(TempDMG, TempLF);
            Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(TempDMG, TempLF);
        }
        TempDMG = 0; TempLF = 0;
    }

    IEnumerator DoubleShootDelay()
    {
        yield return new WaitForSeconds(0.35f);
        this.Shoot(TempDMG, TempLF);
        Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(TempDMG, TempLF);
        Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(TempDMG, TempLF);
        if (Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().enabled)
        {
            Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(TempDMG, TempLF);
            Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(TempDMG, TempLF);
        }
        yield return new WaitForSeconds(0.35f);
        this.Shoot(TempDMG, TempLF);
        Middle_Right_ShotPoint.GetComponent<Middle_Right_ShotPoint>().Shoot(TempDMG, TempLF);
        Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().Shoot(TempDMG, TempLF);
        if (Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().enabled)
        {
            Full_Left_ShotPoint.GetComponent<Full_Left_ShotPoint>().Shoot(TempDMG, TempLF);
            Full_Right_ShotPoint.GetComponent<Full_Right_ShotPoint>().Shoot(TempDMG, TempLF);
        }
        TempDMG = 0; TempLF = 0;
    }
}
