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
                // # 쉘터로 이동한 상태임을 알림
                Player_Stat.instance.isShelter = true;
                // # 쉘터의 귀환용 오브젝트로 플레이어의 위치를 이동시킴
                GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("ReturnHole").GetComponent<Transform>().position;
                Destroy(transform.parent.gameObject);
                // # 생성되었던 스테이지 프리팹을 삭제해주는 작업도 필요하다.
            }               
        }
    }
}
