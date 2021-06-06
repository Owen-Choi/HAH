using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    bool isOnce;
    // # ���� �޴��� ��ũ��Ʈ������ ���� ������ �������� �帧�� �����ϴ� �ڵ带 �ַ� �ٷ� �����̴�. ex : �÷��̾��� ���̾� ���濡 ���� ������Ʈ ����, UI ������Ʈ ���� ��
    public GameObject Player; GameObject PlayerCache;
    public GameObject Tutorial; 
    void Awake()
    {
        PlayerCache = Player;
        Tutorial.gameObject.SetActive(true);
    }

    
    void Update()
    {
        if(PlayerCache.layer != LayerMask.NameToLayer("PlayerInShelter") && !isOnce)       //�÷��̾ ���Ͱ� �ƴ϶�� ���ɰ� �񸶸� ��ġ ���� 
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().StackRadioActive();
            PlayerCache.GetComponent<Player>().StackThirsty();
        }
        if(PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))                                                                    //�÷��̾ ���Ͷ�� ���� ����
        {
            isOnce = false;
            CancelInvoke("StackThirsty");
            CancelInvoke("StackRadioActive");
        }
    }
}
