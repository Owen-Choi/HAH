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
            other.GetComponent<Zombie_Stat>().Health -= (float)Player_Stat.instance.damage * 5 * Player_Stat.instance.Explode_Multiple_Damage;   //������ȭ �� ������Ʈ�� ��ũ��Ʈ���� ������ �� ����. �߿�.
            other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");               //���߿� ������ ������Ʈ�� ������ ȭ���� ����
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
