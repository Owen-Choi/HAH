using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottleFor1 : MonoBehaviour
{
    public GameObject FlameBottleFor2;
    bool isOnce;
    Vector3 shootDirection;
    public Transform Player;
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    public bool isCreate;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        isCreate = false;
        sr.enabled = false;
        isOnce = true;
        sr2 = FlameBottleFor2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCreate && isOnce)
        {
            isOnce = false;
            sr.enabled = false;
            StartCoroutine("CreateDelay");
        }
            

        if(this.sr.enabled && isCreate)
        {
            if (Input.GetMouseButtonDown(1) && !sr2.enabled)
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
