using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour {
    public int Skill_Num;
    public int Sprite_Num;
    public bool Selected;
    public bool Selected_First;
    public bool Selected_Second;
    public bool Selected_Last;
    Skill_Manager[] scripts;
    private void Start()
    {
        scripts = this.GetComponents<Skill_Manager>();
        DontDestroyOnLoad(this);
    }

    public virtual void Activate_First()
    {
        Selected_First = true;
    }


    public virtual void Activate_Second()
    {
        Selected_Second = true;
    }

    public virtual void Activate_Last()
    {
        Selected_Last = true;
        Selected = true;
    }

    public void Update()
    {
       /* if (Player_Stat.instance.isLevelUp)
        {
            LevelUpSkillChoose();
        } */
    }

    public Skill_Manager LevelUpSkillChoose(int Select)
    {
        int frame1; int frame2; int frame3;
        bool Check1 = false; bool Check2 = false; bool Check3 = false;
        Skill_Manager chosen1 = null; Skill_Manager chosen2 = null; Skill_Manager chosen3 = null;
        //Player_Stat.instance.isLevelUp = false;   일단 보류
        int Min = GameObject.Find("SkillChoose").GetComponent<SkillChoose>().MinValue;
        int Max = GameObject.Find("SkillChoose").GetComponent<SkillChoose>().MaxValue;
        // # 스킬넘버 3개를 난수 생성으로 받기
        frame1 = Random.Range(Min, Max + 1);
        do
            frame2 = Random.Range(Min, Max + 1);
        while (frame2 == frame1);

        do
            frame3 = Random.Range(Min, Max + 1);
        while (frame3 == frame2 || frame3 == frame1);
        // # 이미 투자된 스킬이 다시 뜨지 않게 하기
        do
        {
            foreach (Skill_Manager sm in scripts)
            {
                if (sm.Skill_Num == frame1 || sm.Skill_Num == frame2 || sm.Skill_Num == frame3)
                {
                    if (!sm.Selected)
                    {
                        if (!Check1)
                        {
                            chosen1 = sm;
                            Check1 = true;
                            continue;
                        }
                        else if (!Check2)
                        {
                            chosen2 = sm;
                            Check2 = true;
                            continue;
                        }
                        else if (!Check3)
                        {
                            chosen3 = sm;
                            Check3 = true;
                        }
                    }
                    else
                    {   // # 이미 선택된 스킬이라면 frame 3개중에 어떤 frame의 숫자인지 일단 파악한다.
                        frame1 = Random.Range(Min, Max + 1);
                        do
                            frame2 = Random.Range(Min, Max + 1);
                        while (frame2 == frame1);

                        do
                            frame3 = Random.Range(Min, Max + 1);
                        while (frame3 == frame2 || frame3 == frame1);
                        Check1 = Check2 = Check3 = false;
                        break;
                    }

                }
            }
        }
        while (!Check1 || !Check2 || !Check3);                  //정말 비효율적인 알고리즘. 개선할 여지가 많다.
        //Debug.Log(chosen1); Debug.Log(chosen2); Debug.Log(chosen3);

        if (Select == 1)
            return GetChosenOne();
        else if (Select == 2)
            return GetChosenTwo();
        else if (Select == 3)
            return GetChosenThree();
        else
            return null;


        // 이 3개를 이미지화 해서 버튼에 넣고 누르면 Selected 되게 만들어야 한다. 스킬 아이콘의 템플릿은 SkillIcon_(스킬숫자)의 형식이므로 지정만 잘해주면 충분히 여기서 접근할 수 있다.

       Skill_Manager GetChosenOne()
       {
            return chosen1;
       }
        Skill_Manager GetChosenTwo()
        {
            return chosen2;
        }
        Skill_Manager GetChosenThree()
        {
            return chosen3;
        }
    }
}
