using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow_For_Explode : MonoBehaviour
{
   
    GameObject Explode;
    public GameObject Fire_Arrow_ShotPoint;
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
            time += Time.deltaTime;                 //폭발화살의 경우 일정 시간이 지나도록 적과의 접촉이 없다면 혼자서 폭발한다.
            if (time > 1.5f)
            {
                Instantiate(Resources.Load("Explode"), this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
                
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EdgeCol.isTrigger = false;

            Instantiate(Resources.Load("Explode"), this.transform.position, this.transform.rotation);                 //폭발 생성

            StartCoroutine("DestroyDelay");
        }

    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
