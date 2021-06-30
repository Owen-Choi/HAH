using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArrow_For_Crit : MonoBehaviour
{
    EdgeCollider2D EdgeCol;
    GameObject temp;
    public bool Launched;   float time;
    Vector3 vec;    float DMG;
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
            vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
            EdgeCol.isTrigger = false;
            //�淮ȭ���� ��� �ݹ� �������� ũ��Ƽ���� �����Ǿ� ȭ���� ������Ʈ�� �ٲ��. ũ��Ƽ�� ȭ���� ��� �ݵ�� ġ��Ÿ�� ����ȴ�.
            if (Player_Stat.instance.AbsolCrit)
            {
                Player_Stat.instance.AbsolCrit = false;         //������ ��ųüũ�� ���� ġ��Ÿ�� ��� 
            }
            DMG = ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
            other.GetComponent<Zombie_Stat>().Health -= DMG;
            StartCoroutine("DestroyDelay");
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
