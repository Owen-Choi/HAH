using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArrow_For_Crit : MonoBehaviour
{
    EdgeCollider2D EdgeCol;
    public bool Launched;   float time; float DMG;
    GameObject temp;
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
            Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
            EdgeCol.isTrigger = false;
            //경량화살의 경우 격발 시점에서 크리티컬이 결정되어 화살의 오브젝트가 바뀐다. 크리티컬 화살의 경우 반드시 치명타로 적용된다.
            if (Player_Stat.instance.AbsolCrit)
            {
                Player_Stat.instance.AbsolCrit = false;         //역마살 스킬체크로 인한 치명타일 경우 
            }
            DMG = ((Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
            other.GetComponent<Zombie_Stat>().Health -= DMG;
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();
            //CameraShake.instance.cameraShake();
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
