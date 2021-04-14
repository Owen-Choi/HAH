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
            //�淮ȭ���� ��� �ݹ� �������� ũ��Ƽ���� �����Ǿ� ȭ���� ������Ʈ�� �ٲ��. �Ϲ� ȭ���� ��� ũ��Ƽ���� ���� �ʴ´�.
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
