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
                SceneManager.LoadScene("Shelter");                      //���� ����.���� �� ������Ʈ�� �����Ǵ� �ñ⸦ ��� �ϸ� ���� �� �����غ���
        }
    }
}
