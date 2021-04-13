using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow_For_Explode : MonoBehaviour
{
   
    GameObject Explode;
    public GameObject Fire_Arrow_ShotPoint;
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


            if(Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().is_Explode && Random.Range(0,100) < Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().Explode_Percent)
                Instantiate(Resources.Load("Explode"), this.transform.position, this.transform.rotation);                 //Æø¹ß »ý¼º

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
