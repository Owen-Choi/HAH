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
        // # 아직은 맵이 하나밖에 없지만 2개 이상 만들어질 경우 랜덤으로 맵이 선택되게 하기(스테이지 숫자를 랜덤으로 받고 실행하면 된다)
        Instantiate(Resources.Load("Forest_Stage_1"));
        PlayerCache.transform.position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
        PlayerCache.layer = LayerMask.NameToLayer("Player");                                                //플레이어의 레이어를 PlayerInShelter에서 Player로 변경한다.
        PlayerCache.GetComponent<Player>().StackRadioActive();

    }
}
