using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottleFor3 : MonoBehaviour
{
    public bool isActive;
    bool isOnce; Vector3 shootDirection; public Transform Player; public GameObject FlameBottle;    public Transform FireArrowShotPoint;
    public GameObject FlameBottleFor2;
    public bool isCreate;
    void Start()
    {     
        isCreate = false;       
        isOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCreate && FlameBottleFor2.GetComponent<FlameBottleFor2>().isCreate && isOnce && isActive)
        {
            isOnce = false;                         //딱 한번만 조건문을 발동하기 위한 장치.
            StartCoroutine("CreateDelay");
        }

        if (!FlameBottleFor2.GetComponent<FlameBottleFor2>().isCreate)
        {
            StopCoroutine("CreateDelay");
            isOnce = true;
        }

        if (isCreate)
        {
            if (Input.GetMouseButtonDown(1))
                Throw();
        }

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

        GameObject newBottle = Instantiate(FlameBottle, FireArrowShotPoint.position, FireArrowShotPoint.transform.rotation) as GameObject;
        newBottle.GetComponent<Rigidbody2D>().velocity = shootDirection;
        StartCoroutine("ChangeDelay");
    }

    IEnumerator CreateDelay()
    {
        yield return new WaitForSeconds(10f);
        isCreate = true;
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(0.25f);
        isCreate = false;
        isOnce = true;
    }
}
