using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : Physical_Manager
{
    // # 좀비의 종류가 늘어난다면 여기에 추가해주기
    // # 이거 안될텐데??
    public Zombie_AI AIscript;    
    public Zombie_AI_For_TypeA AIscriptForA;    //이 스크립트를 다른 곳에서 참조할 방법이 필요하다.

    private void Awake()
    {
        //AIscript = GetComponent<Zombie_AI>();
        //AIscriptForA = GetComponent<Zombie_AI_For_TypeA>();
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            AIscript.MoveSpeed -= 0.05f;
            AIscriptForA.MoveSpeed -= 0.05f;
        }
    }
}
