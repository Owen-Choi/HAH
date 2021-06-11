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
                // # ���ͷ� �̵��� �������� �˸�
                Player_Stat.instance.isShelter = true;
                // # ������ ��ȯ�� ������Ʈ�� �÷��̾��� ��ġ�� �̵���Ŵ
                GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("ReturnHole").GetComponent<Transform>().position;
                Destroy(transform.parent.gameObject);
                // # �����Ǿ��� �������� �������� �������ִ� �۾��� �ʿ��ϴ�.
            }               
        }
    }
    */
    private void Update()
    {
        // # �÷��̾ �̵���Ŵ�� ���ÿ� ���̾ PlayerInShelter�� �ٲ��־�� �Ѵ�.

        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));
        if (circle)
        {

            GuideUICache.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PlayerCache.layer = LayerMask.NameToLayer("PlayerInShelter");
                PlayerCache.GetComponent<Player>().StopRadioActive();               //���ͷ� ���ư��� ���� ���� ����
                GuideUICache.SetActive(false);
                PlayerCache.GetComponent<Transform>().position = GameObject.Find("ReturnHole").GetComponent<Transform>().position;
                Destroy(this.transform.root.gameObject);                            //���� ��°�� ���ֱ� ���� �ڵ�
            }

        }
        else
            GuideUICache.SetActive(false);
    }
}
