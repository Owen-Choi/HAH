using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlameBottleFor2 : MonoBehaviour
{
    public bool isActive;
    bool isOnce;    Vector3 shootDirection; public Transform FireArrowShotPoint;    public GameObject FlameBottleFor3; public GameObject FlameBottle;
    public GameObject FlameBottleFor1;
    public bool isCreate;
    public GameObject FlameBottleUI;
    GameObject FlameBottleUICache; Color Active; Color Deactive;
    void Start()
    {      
        isCreate = false;       
        isOnce = true;
        FlameBottleUICache = FlameBottleUI;
        Active.r = 255; Active.g = 255; Active.b = 255; Active.a = 1f;
        Deactive.r = 255; Deactive.g = 255; Deactive.b = 255; Deactive.a = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCreate && FlameBottleFor1.GetComponent<FlameBottleFor1>().isCreate && isOnce && isActive)
        {
            isOnce = false;                         //딱 한번만 조건문을 발동하기 위한 장치.
            StartCoroutine("CreateDelay");
        }

        if (!FlameBottleFor1.GetComponent<FlameBottleFor1>().isCreate)
        {
            StopCoroutine("CreateDelay");
            isOnce = true;
        }

        if(isCreate)
        {
            FlameBottleUICache.GetComponent<Image>().color = Active;
            if (Input.GetMouseButtonDown(1) && !FlameBottleFor3.GetComponent<FlameBottleFor3>().isCreate || Input.GetMouseButtonDown(1) && !FlameBottleFor3.GetComponent<FlameBottleFor3>().isActive)
                Throw();
        }
        else
            FlameBottleUICache.GetComponent<Image>().color = Deactive;

    }

    void Throw()
    {
        shootDirection = Input.mousePosition;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();


        float degree = Mathf.Atan2(difference.y, difference.x);
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        shootDirection.x = (float)5f * Mathf.Cos(degree);
        shootDirection.y = (float)5f * Mathf.Sin(degree);

        GameObject newBottle = Instantiate(Resources.Load("FlameBottle"), FireArrowShotPoint.position, FireArrowShotPoint.transform.rotation) as GameObject;
        newBottle.GetComponent<Rigidbody2D>().velocity = shootDirection;
        StartCoroutine("ChangeDelay");
    }

    IEnumerator CreateDelay()
    {
        yield return new WaitForSeconds(6f);
        isCreate = true;
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(0.25f);
        isCreate = false;
        isOnce = true;
    }
}
