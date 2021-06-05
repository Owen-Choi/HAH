using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow : MonoBehaviour
{
    GameObject temp;
    float DMG;  float DMGForCrit;
    public bool isSoot;                             //������ ��ųüũ ����
    public float countTime;
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
            //ġ��Ÿ �����
            if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit)
            {
                DMGForCrit = ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
                Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
                other.GetComponent<Zombie_Stat>().Health -= DMGForCrit;
                temp = Instantiate(Resources.Load("FloatingParentsForCrit"), vec, Quaternion.identity) as GameObject;
                temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMGForCrit.ToString();
                CameraShake.instance.cameraShake();
            }
            //ġ��Ÿ �������
            else
            {
                DMG = Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage;
                Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
                other.GetComponent<Zombie_Stat>().Health -= DMG;
                temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
                temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();
            }
            if (Random.Range(0,100) < Player_Stat.instance.Burn_Percent)
            {
                if(isSoot)
                    other.gameObject.layer = LayerMask.NameToLayer("Master_Burned");                //������ ��ųüũ �� ȭ���� �����Ǵ� Master_Burned ���̾�� �ٲ� 
                else
                    other.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
            }
            StartCoroutine("DestroyDelay");
        }
    }

   IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
