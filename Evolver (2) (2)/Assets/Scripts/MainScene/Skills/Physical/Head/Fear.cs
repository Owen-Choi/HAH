using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : Physical_Manager
{
    // # ������ ������ �þ�ٸ� ���⿡ �߰����ֱ�
    // # �̰� �ȵ��ٵ�??
    public Zombie_AI AIscript;    
    public Zombie_AI_For_TypeA AIscriptForA;    //�� ��ũ��Ʈ�� �ٸ� ������ ������ ����� �ʿ��ϴ�.

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
