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
            if (Random.Range(0, 100) < Player_Stat.instance.Burn_Percent)
            {
                other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
            }
            StartCoroutine("DestroyDelay");
        }

        if (other.tag == "border")
            Destroy(gameObject);
    }

   IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
