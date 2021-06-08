using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    bool DamageOnce;
    Animator anim;  float radius = 0.75f;   int i;
    Vector3 vec;    GameObject temp;    float ExplodeDMG;   Vector2 Direction;
    AudioSource audio;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isEnter", true);
        audio.Play();
       
    }


    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !DamageOnce)
        {
            DamageOnce = true;
            ExplodeDMG = (float)Player_Stat.instance.damage * 5 * Player_Stat.instance.Explode_Multiple_Damage;
            other.GetComponent<Zombie_Stat>().Health -= ExplodeDMG;   //������ȭ �� ������Ʈ�� ��ũ��Ʈ���� ������ �� ����. �߿�.
            vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);     //Vector2�� �Ǵ� �� �𸣰ڴ�.
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = ExplodeDMG.ToString();
            other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");               //���߿� ������ ������Ʈ�� ������ ȭ���� ����
        }
    }*/

    private void Update()
    {
        if (anim.GetBool("isEnter"))
            StartCoroutine("Explosion_Persist");
        int layerMask = (1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("EnemyChasing") | (1 << LayerMask.NameToLayer("Servant_Burned")) | 1 << LayerMask.NameToLayer("Master_Burned"));
        RaycastHit2D[] circle = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, radius, layerMask);

        if (circle[0])
        {
            ExplodeDMG = (float)Player_Stat.instance.damage * 5 * Player_Stat.instance.Explode_Multiple_Damage;
            for (i = 0; i<circle.Length; i++)
            {
                if(circle[i].transform.tag == "Enemy_Bug")
                {
                    Destroy(circle[i].transform.parent.gameObject);
                    continue;
                }
                circle[i].transform.gameObject.GetComponent<Zombie_Stat>().Health -= ExplodeDMG;
                // # �������� UI�� ǥ�����ִ� �ڵ�
                vec = new Vector3(circle[i].transform.position.x, circle[i].transform.position.y + 0.5f, 0f);     //Vector2�� �Ǵ� �� �𸣰ڴ�.
                temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
                temp.transform.GetChild(0).GetComponent<TextMesh>().text = ExplodeDMG.ToString();
                circle[i].transform.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
                // # ���� �о�� �ڵ�
                Direction = (circle[i].transform.position - this.transform.position).normalized;
                circle[i].transform.GetComponent<Rigidbody2D>().AddForce(Direction * 5000);
            }
        }
    }
    IEnumerator Explosion_Persist()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
