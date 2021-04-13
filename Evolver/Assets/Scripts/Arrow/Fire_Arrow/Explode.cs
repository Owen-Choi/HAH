using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    bool DamageOnce;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isEnter", true);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !DamageOnce)
        {
            DamageOnce = true;
            other.GetComponent<Zombie_Stat>().Health -= 50;                                 //sample code
            other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");               //폭발에 접촉한 오브젝트는 무조건 화상을 입음
        }
    }

    private void Update()
    {
        if (anim.GetBool("isEnter"))
            StartCoroutine("Explosion_Persist");
    }
    IEnumerator Explosion_Persist()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
