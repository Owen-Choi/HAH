using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSample : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //����� �÷��� �߰� ����
        }
    }
    //�Ұ����� ���� : �� ������Ʈ�� ������ȭ �� �������� �ٸ� Ŭ������ ������Ʈ���� ������ �Ұ����� �� ����.
    /*private void OnDestroy()
    {
        BackPack.GetComponent<BackPack>().AddItem("MuntantSample", Random.Range(1, 4));
    }*/
}
