using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class HoamingArrow : MonoBehaviour
{
    EdgeCollider2D EdgeCol;
    public bool Launched; float time;
    float radius = 15f;
    int layermask;
    bool forOnce;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
        layermask = (1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("Servant_Burned") | (1 << LayerMask.NameToLayer("Master_Burned")) | 1 << LayerMask.NameToLayer("EnemyChasing"));
    }


    private void Update()
    {
        if (Launched)
        {
            time += Time.deltaTime;
            if (time > 5f)
                Destroy(this.gameObject);
        }
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, layermask);
        if (circle && !forOnce)
        {
            forOnce = true;
            this.GetComponent<AIDestinationSetter>().target = circle.transform;
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
