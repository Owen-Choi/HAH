using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottleFor2 : MonoBehaviour
{
    bool isOnce;    Vector3 shootDirection; public Transform Player;    public GameObject FlameBottleFor3;
    public GameObject FlameBottleFor1;
    public SpriteRenderer sr;
    public SpriteRenderer sr3;
    bool isCreate;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        isCreate = false;
        sr.enabled = false;
        isOnce = true;
        sr3 = FlameBottleFor3.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCreate && FlameBottleFor1.GetComponent<FlameBottleFor1>().sr.enabled && isOnce)
        {
            isOnce = false;                         //딱 한번만 조건문을 발동하기 위한 장치.
            sr.enabled = false;
            StartCoroutine("CreateDelay");
        }

        if (!FlameBottleFor1.GetComponent<FlameBottleFor1>().sr.enabled)
        {
            StopCoroutine("CreateDelay");
            isOnce = true;
        }

        if(this.sr.enabled)
        {
            if (Input.GetMouseButtonDown(1) && !sr3.enabled)
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

        GameObject newBottle = Instantiate(Resources.Load("FlameBottle"), Player.position, Player.transform.rotation) as GameObject;
        newBottle.GetComponent<Rigidbody2D>().velocity = shootDirection;
        isCreate = false;
        isOnce = true;
    }

    IEnumerator CreateDelay()
    {
        yield return new WaitForSeconds(10f);
        isCreate = true;
        sr.enabled = true;
    }
}
