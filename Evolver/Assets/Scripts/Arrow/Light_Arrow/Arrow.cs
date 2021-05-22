using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float DMG;
    GameObject temp;
    EdgeCollider2D EdgeCol;
    void Awake()
    {
        EdgeCol = GetComponent<EdgeCollider2D>();
    }

    // # 스테이지에 있는 화살을 복사해서 사용하는 시스템이기 때문에 조건 없이 시간이 지나면 사라지는 식의 코드는 사용할 수 없다.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;
            //경량화살의 경우 격발 시점에서 크리티컬이 결정되어 화살의 오브젝트가 바뀐다. 일반 화살의 경우 크리티컬이 뜨지 않는다.
            Vector3 vec = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, 0f);
            DMG = Player_Stat.instance.damage + this.GetComponent<Arrow_Damage_System>().HoldDamage;
            other.GetComponent<Zombie_Stat>().Health -= DMG;
            temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
            temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();      //첫번째 자식(floatingPoints를 가리킴)의 요소를 얻기 위한 코드
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
