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
            time += Time.deltaTime;                 //����ȭ���� ��� ���� �ð��� �������� ������ ������ ���ٸ� ȥ�ڼ� �����Ѵ�.
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

            Instantiate(Resources.Load("Explode"), this.transform.position, this.transform.rotation);                 //���� ����

            StartCoroutine("DestroyDelay");
        }

    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
