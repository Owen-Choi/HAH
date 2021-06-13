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
    public Skill_Manager[] scripts;
    public string Skill_Name;       // ��ų �̸��� ������ ����
    public string Skill_Desc;       // ��ų ������ ������ ����
    private void Start()
    {
        scripts = this.GetComponents<Skill_Manager>();
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
        //Player_Stat.instance.isLevelUp = false;   �ϴ� ����
        int Min = GameObject.Find("SkillChoose").GetComponent<SkillChoose>().MinValue;
        int Max = GameObject.Find("SkillChoose").GetComponent<SkillChoose>().MaxValue;
        // # ��ų�ѹ� 3���� ���� �������� �ޱ�
        frame1 = Random.Range(Min, Max+1);
        frame2 = Random.Range(Min, Max+1);
        frame3 = Random.Range(Min, Max+1);
        // # ��ų �ߺ� ������ ���õ� ��ų üũ ������ ������ ���� ���ݴ�. 
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
                    {   // # �̹� ���õ� ��ų�̶�� frame 3���߿� � frame�� �������� �ϴ� �ľ��Ѵ�.
                        frame1 = Random.Range(Min, Max + 1);
                        frame2 = Random.Range(Min, Max + 1);
                        frame3 = Random.Range(Min, Max + 1);
                        break;
                    }
                }
            }
        }
        while (!Check1 || !Check2 || !Check3);                  //���� ��ȿ������ �˰�����. ������ ������ ����.
        //Debug.Log(chosen1); Debug.Log(chosen2); Debug.Log(chosen3);


        // # �ѹ��� �ϳ����ۿ� return�� �ȵż� �̷��� �ڵ带 ®�µ� �� �ڵ� ������ ��ų���� �ߺ��Ǿ� ��Ÿ����.
        if (Select == 1)
            return GetChosenOne();
        else if (Select == 2)
            return GetChosenTwo();
        else if (Select == 3)
            return GetChosenThree();
        else
            return null;

        // # �� ��ȯ�� �Ͼ�� ������ �ý��ۿ��� �ʿ��ߴ� �ڵ�. ������ �� ���� ����� ������ �ϴ� �״�� ����ϰڴ�.
        // �� 3���� �̹���ȭ �ؼ� ��ư�� �ְ� ������ Selected �ǰ� ������ �Ѵ�. ��ų �������� ���ø��� SkillIcon_(��ų����)�� �����̹Ƿ� ������ �����ָ� ����� ���⼭ ������ �� �ִ�.

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