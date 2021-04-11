using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float countTime;
    EdgeCollider2D EdgeCol;
    public float HoldDamage;
    public float HoldLaunchForce;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
        }

        if (other.tag == "border")
            Destroy(gameObject);
    }

    void Update()
    {
        if(EdgeCol.isTrigger == false)
        {
            countTime += Time.deltaTime;
            if(countTime > 0.2f)
                Destroy(gameObject);
        }
    }

}
