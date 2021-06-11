using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToShelter : MonoBehaviour
{
    float radius = 1f;
    GameObject PlayerCache;
    GameObject GuideUICache;
    private void Start()
    {
        PlayerCache = GameObject.Find("Player");
        GuideUICache = GameObject.Find("Guide").transform.GetChild(1).gameObject;
    }
    /*private void OnTriggerStay2D(Collider2D collision)
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
    */
    private void Update()
    {
        // # 플레이어를 이동시킴과 동시에 레이어를 PlayerInShelter로 바꿔주어야 한다.

        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));
        if (circle)
        {

            GuideUICache.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PlayerCache.layer = LayerMask.NameToLayer("PlayerInShelter");
                PlayerCache.GetComponent<Player>().StopRadioActive();               //쉘터로 돌아가면 방사능 축적 종료
                GuideUICache.SetActive(false);
                PlayerCache.GetComponent<Transform>().position = GameObject.Find("ReturnHole").GetComponent<Transform>().position;
                Destroy(this.transform.root.gameObject);                            //맵을 통째로 없애기 위한 코드
            }

        }
        else
            GuideUICache.SetActive(false);
    }
}
