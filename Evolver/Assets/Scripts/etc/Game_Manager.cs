using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    bool isOnce;
    // # 게임 메니저 스크립트에서는 게임 진행의 전반적인 흐름을 제어하는 코드를 주로 다룰 예정이다. ex : 플레이어의 레이어 변경에 따른 오브젝트 수정, UI 오브젝트 조정 등
    public GameObject Player; GameObject PlayerCache;
    public GameObject Tutorial; 
    void Awake()
    {
        PlayerCache = Player;
        Tutorial.gameObject.SetActive(true);
    }

    
    void Update()
    {
        if(PlayerCache.layer != LayerMask.NameToLayer("PlayerInShelter") && !isOnce)       //플레이어가 쉘터가 아니라면 방사능과 목마름 수치 증가 
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().StackRadioActive();
            PlayerCache.GetComponent<Player>().StackThirsty();
        }
        if(PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))                                                                    //플레이어가 쉘터라면 축적 멈춤
        {
            isOnce = false;
            CancelInvoke("StackThirsty");
            CancelInvoke("StackRadioActive");
        }
    }
}
