using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMapTest : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        // # ���� ����ȭ�Ǿ��� ������ �� ��ȯ�� �ƴ϶� ��ġ�� �̵������־�� �Ѵ�. UI�� �����Ͽ� Ư�� ��ư�� ������ �̵��ϴ� ������ ������ �� �ϴ�. 
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Instantiate(Resources.Load("Stage_1"));
                GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
            }
            // Player_Stat.instance.IsShelter = false;
        }
    }
}
