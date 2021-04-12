using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow : MonoBehaviour
{
    public float countTime;
    EdgeCollider2D EdgeCol;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
            Destroy(gameObject);
            if (Random.Range(0, 100) < Player_Stat.instance.Burn_Percent)
                other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
        }

        if (other.tag == "border")
            Destroy(gameObject);
    }

    
}
