using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie_Stat : MonoBehaviour
{
    bool isOnce;
    Rigidbody2D rigid;
    int i;   int CurrentFireborne;
    public bool is_burned;  public float Burning_DMG;     //��ų ���� ������
    public float Health;
    public float Power;
    float Second;   float dropNum;
    GameObject BackPackCache;
    GameObject temp;    Vector2 vec;
    private void Start()
    {
        CurrentFireborne = 0;
        rigid = GetComponent<Rigidbody2D>();
        BackPackCache = GameObject.Find("BackPack");
    }

   /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")                     //��ȭ���� ���� Fire_Arrow�� ��ũ��Ʈ���� Ȯ�������� ȭ�� ���·� ���̾ �����Ѵ�.
        {
            if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit)              //AbsolCrit�� 100%�� Ȯ���� ũ��Ƽ�� ��Ʈ�� �����Ѵ�.
            {
                if (Player_Stat.instance.AbsolCrit)
                {
                    Player_Stat.instance.AbsolCrit = false;
                }
                Health -= ((Player_Stat.instance.damage + other.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
                CameraShake.instance.cameraShake();
            }
            else
                Health -= (Player_Stat.instance.damage + other.GetComponent<Arrow_Damage_System>().HoldDamage);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && this.gameObject.layer == LayerMask.NameToLayer("Master_Burned") && CurrentFireborne <= Player_Stat.instance.FireborneMax)
        {
            collision.gameObject.layer = LayerMask.NameToLayer("Master_Burned");
            CurrentFireborne++;
        }
    }

    private void Update()
    {
        Burning_DMG = Player_Stat.instance.Burning_DMG;

        if (Health <= 0)
            Destroy(gameObject);

        //ȭ�� ���̾�� �ش� ���ǹ��� ��� üũ�ؼ� ������ ���Ǵ� ���� �߻�, isOnce ���� �߰��ؼ� ��ġ
        if(this.gameObject.layer == LayerMask.NameToLayer("Servant_Burned") || this.gameObject.layer == LayerMask.NameToLayer("Master_Burned")) //����Ʈ, Ȥ�� ������ ������ ȭ������ üũ
        {
            if (Player_Stat.instance.isPyro && Random.Range(0, 100) <= 2 && !isOnce)
            {
                CameraShake.instance.cameraShake();
                Destroy(this.gameObject);
                isOnce = false; 
            }
            else
            {
                isOnce = true;
                is_burned = true;                                                       //this line makes Burning Animation Start by Changing its value
                StartCoroutine("Burning_Time");
            }

            Second += Time.deltaTime;
            if ((int)Second % 1 == 0 && Second > 1f)
            {
                Second = 0f;
                vec = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, 0f);     //Vector2�� �Ǵ� �� �𸣰ڴ�.
                temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
                temp.transform.GetChild(0).GetComponent<TextMesh>().text = Player_Stat.instance.Burning_DMG.ToString();
                Health -= Player_Stat.instance.Burning_DMG;                             //�ڷ�ƾ ��ſ� 1�ʸ��� ȭ�� �������� �Դ� �������� ����
            }
        }

    }

    IEnumerator Burning_Time()
    {
        yield return new WaitForSeconds(Player_Stat.instance.burningTime);
        is_burned = false;
        CurrentFireborne = 0;                                                     //������ ���� ������ 0���� �ʱ�ȭ�ؼ� �ٽ� ������ �����ϵ��� ������ֱ�
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");                   //may cause some errors. if there are not only Enemy layers, this code should be changed 
        Second = 0f;
    }



    private void OnDestroy()
    {

        // �ٸ� ����� ���� ��¿ �� ���� Ȯ���� ���� ������ �ѹ��� �� üũ�ϴ� �ý������� �ڵ��ߴ�.
        dropNum = Random.Range(0, 100);
        Instantiate(Resources.Load("Zombie_Dead"), this.transform.position, this.transform.rotation);
        if (dropNum < BackPackCache.GetComponent<BackPack>().GetDropPercent("Medikit"))  //���� -> �κ��丮 ������ ����
        {
            Instantiate(Resources.Load("Medikit"), this.transform.position, Quaternion.identity);
            return;
        }

        dropNum = Random.Range(0, 100);
        if (dropNum < BackPackCache.GetComponent<BackPack>().GetDropPercent("StaminaPotion"))
        {
            Instantiate(Resources.Load("StaminaPotion"), this.transform.position, Quaternion.identity);
            return;
        }

        dropNum = Random.Range(0, 100);
        if (dropNum < BackPackCache.GetComponent<BackPack>().GetDropPercent("Bandage"))
        {
            Instantiate(Resources.Load("Bandage"), this.transform.position, Quaternion.identity);
            return;
        }

        dropNum = Random.Range(0, 100);
        if (dropNum < BackPackCache.GetComponent<BackPack>().GetDropPercent("Water"))
        { 
                Instantiate(Resources.Load("Water"), this.transform.position, Quaternion.identity);
            return;
        }
        dropNum = Random.Range(0, 100);
        if (dropNum < BackPackCache.GetComponent<BackPack>().GetDropPercent("Food"))
        {
            Instantiate(Resources.Load("Food"), this.transform.position, Quaternion.identity);
            return;
        }

    }

}
