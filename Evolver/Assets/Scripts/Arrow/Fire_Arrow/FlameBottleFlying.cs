using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottleFlying : MonoBehaviour
{
    
    void Start()
    {
        
    }

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag == "border")
        {
            Instantiate(Resources.Load("Explode"), this.gameObject.transform.position, this.transform.rotation);        //ȭ���� ���� ���� ���� ����
            Destroy(gameObject);
        }
    }
}
