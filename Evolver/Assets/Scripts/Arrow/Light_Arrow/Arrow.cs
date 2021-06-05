using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float DMG;
    GameObject temp;
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
        if (other.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
            //�淮ȭ���� ��� �ݹ� �������� ũ��Ƽ���� �����Ǿ� ȭ���� ������Ʈ�� �ٲ��. �Ϲ� ȭ���� ��� ũ��Ƽ���� ���� �ʴ´�.
            Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
            DMG = Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage;
            other.GetComponent<Zombie_Stat>().Health -= DMG;
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();      //ù��° �ڽ�(floatingPoints�� ����Ŵ)�� ��Ҹ� ��� ���� �ڵ�
            StartCoroutine("DestroyDelay");
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

}
