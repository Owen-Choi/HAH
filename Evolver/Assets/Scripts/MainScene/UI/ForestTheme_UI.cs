using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTheme_UI : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public void FirstButtonPress()
    {
        // # 맵 프리팹 생성 후 플레이어를 SpawnPoint로 이동.   SpawnPoint가 많아지면 문제가 생길 수도 있다.
        Instantiate(Resources.Load("Forest_Stage_1"));
        GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
    }

    // 위와 같은 형식으로 Button들 추가하기.
}
