using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlameBottleFor1 : MonoBehaviour
{
    public bool isActive;
    public GameObject FlameBottleFor2;  public GameObject FlameBottle;  public Transform FireArrowShotPoint;
    bool isOnce;
    Vector3 shootDirection;
    public Transform Player;
    public bool isCreate;
    public GameObject FlameBottleUI;
    GameObject FlameBottleUICache;  Color Active;   Color Deactive;
    void Awake()
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
        if (!isCreate && isOnce && isActive)
        {
            isOnce = false;
            StartCoroutine("CreateDelay");
        }
            

        if(isCreate)
        {
            FlameBottleUICache.GetComponent<Image>().color = Active;
            if (Input.GetMouseButtonDown(1) && !FlameBottleFor2.GetComponent<FlameBottleFor2>().isCreate || Input.GetMouseButtonDown(1) && !FlameBottleFor2.GetComponent<FlameBottleFor2>().isActive)
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
        isCreate = false;
        isOnce = true;
    }

    IEnumerator CreateDelay()
    {
        yield return new WaitForSeconds(6f);
        isCreate = true;
    }
}
