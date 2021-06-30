using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ForestButton : MonoBehaviour
{
    Color Oncolor;
    Color ExitColor;
    public GameObject Player;
    GameObject PlayerCache;
    public void Awake()
    {
        Oncolor.r = 101;    ExitColor.r = 255;
        Oncolor.g = 75;     ExitColor.g = 255;
        Oncolor.b = 75;     ExitColor.b = 255;
        Oncolor.a = 0.4f;   ExitColor.a = 0f;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        PlayerCache = Player;
    }
    public void OnMouseEnter()
    {
        this.gameObject.GetComponent<Image>().color = Oncolor;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        this.gameObject.GetComponent<Image>().color = ExitColor;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnClick()
    {
        // # ������ ���� �ϳ��ۿ� ������ 2�� �̻� ������� ��� �������� ���� ���õǰ� �ϱ�(�������� ���ڸ� �������� �ް� �����ϸ� �ȴ�)
        Instantiate(Resources.Load("Forest_Stage_1"));
        PlayerCache.transform.position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
        PlayerCache.layer = LayerMask.NameToLayer("Player");                                                //�÷��̾��� ���̾ PlayerInShelter���� Player�� �����Ѵ�.
        PlayerCache.GetComponent<Player>().StackRadioActive();

    }
}
