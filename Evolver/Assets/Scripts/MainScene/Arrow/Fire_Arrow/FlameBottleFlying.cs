using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottleFlying : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 350f) * Time.deltaTime);

    }

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag == "border")
        {
            Instantiate(Resources.Load("Explode"), this.gameObject.transform.position, this.transform.rotation);        //화염병 전용 폭발 생성 예정
            Destroy(gameObject);
        }
    }
}
