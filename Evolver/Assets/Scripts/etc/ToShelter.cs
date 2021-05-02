using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToShelter : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // # ���ͷ� �̵��� �������� �˸�
                Player_Stat.instance.isShelter = true;
                // # ������ ��ȯ�� ������Ʈ�� �÷��̾��� ��ġ�� �̵���Ŵ
                GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("ReturnHole").GetComponent<Transform>().position;
                Destroy(transform.parent.gameObject);
                // # �����Ǿ��� �������� �������� �������ִ� �۾��� �ʿ��ϴ�.
            }               
        }
    }
}
