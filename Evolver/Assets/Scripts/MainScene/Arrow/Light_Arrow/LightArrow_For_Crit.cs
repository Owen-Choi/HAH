using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArrow_For_Crit : MonoBehaviour
{
    EdgeCollider2D EdgeCol;
    public bool Launched;   float time;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
    }


    private void Update()
    {
        if (Launched)
        {
            time += Time.deltaTime;
            if (time > 1f)
                Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
            //�淮ȭ���� ��� �ݹ� �������� ũ��Ƽ���� �����Ǿ� ȭ���� ������Ʈ�� �ٲ��. ũ��Ƽ�� ȭ���� ��� �ݵ�� ġ��Ÿ�� ����ȴ�.
            if (Player_Stat.instance.AbsolCrit)
            {
                Player_Stat.instance.AbsolCrit = false;         //������ ��ųüũ�� ���� ġ��Ÿ�� ��� 
            }
            other.GetComponent<Zombie_Stat>().Health -= ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
            CameraShake.instance.cameraShake();
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
