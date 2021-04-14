using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
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
            //경량화살의 경우 격발 시점에서 크리티컬이 결정되어 화살의 오브젝트가 바뀐다. 일반 화살의 경우 크리티컬이 뜨지 않는다.
            other.GetComponent<Zombie_Stat>().Health -= (Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage);

            StartCoroutine("DestroyDelay");
        }

        if (other.tag == "border")
            StartCoroutine("DestroyDelay");
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

}
