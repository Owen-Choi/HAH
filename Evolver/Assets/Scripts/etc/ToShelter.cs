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
                SceneManager.LoadScene("Shelter");                      //오류 없음.이제 이 오브젝트가 생성되는 시기를 어떻게 하면 좋을 지 생각해보기
        }
    }
}
