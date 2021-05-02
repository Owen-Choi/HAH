using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMapTest : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        // # 씬이 단일화되었기 때문에 씬 전환이 아니라 위치를 이동시켜주어야 한다. UI와 연계하여 특정 버튼을 누르면 이동하는 식으로 가야할 듯 하다. 
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
