using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapUI : MonoBehaviour
{
    public Canvas ForestTheme;
    public Canvas SchoolTheme;
    public Canvas CityTheme;
    public Canvas BasicUI;

    private void Awake()
    {
        // # 지도 UI가 떠있는 동안에는 다른 UI를 비활성화
        BasicUI.gameObject.SetActive(false);    
    }
    public void FirstButtonPress()
    {
        // # MapChoose UI를 비활성화 하고 해당 버튼의 테마 UI를 활성화
        this.transform.parent.gameObject.SetActive(false);
        ForestTheme.gameObject.SetActive(true);                         //각 테마의 스크립트들이 해야할 기능 : 스테이지 프리팹 생성 및 플레이어 이동, 다시 기본 UI 띄우기
    }

    public void SecondButtonPress()
    {
        this.transform.parent.gameObject.SetActive(false);
        SchoolTheme.gameObject.SetActive(true);
    }
    public void ThridButtonPress()
    {
        this.transform.parent.gameObject.SetActive(false);
        CityTheme.gameObject.SetActive(true);
    }

}
