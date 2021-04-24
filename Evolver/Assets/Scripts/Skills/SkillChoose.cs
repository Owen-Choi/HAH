using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChoose : MonoBehaviour
{
    public GameObject WeaponChoose;
    Skill_Manager One;   public int frame1;
    Skill_Manager Two;   public int frame2;
    Skill_Manager Three; public int frame3;
    Skill_Manager[] scripts;
    public int MinValue;   public int MaxValue;

    private void Awake()
    {
        // # �� ���� �˰����� ���� ���̴�.
        scripts = GetComponents<Skill_Manager>();
        One = GetComponent<Skill_Manager>();
        Two = GetComponent<Skill_Manager>();
        Three = GetComponent<Skill_Manager>();
    }
    private void Start()
    {
        if (WeaponChoose.GetComponent<WeaponChoose>().isLight)
        {
            MinValue = 1;
            MaxValue = 6;
        }
        else if (WeaponChoose.GetComponent<WeaponChoose>().isSilver)
        {
            MinValue = 15;
            MaxValue = 19;
        }
        else if (WeaponChoose.GetComponent<WeaponChoose>().isFire)
        {
            MinValue = 25;
            MaxValue = 29;
        }
    }

    void Update()
    {
        if (Player_Stat.instance.isLevelUp)
        {
            Player_Stat.instance.isLevelUp = false;

            frame1 = Random.Range(MinValue, MaxValue + 1);
            do
                frame2 = Random.Range(MinValue, MaxValue + 1);
            while (frame2 != frame1);

            do
                frame3 = Random.Range(MinValue, MaxValue + 1);
            while (frame3 != frame2 && frame3 != frame1);

            foreach (Skill_Manager sm in scripts)
            {
                if (sm.Skill_Num == frame1 || sm.Skill_Num == frame2 || sm.Skill_Num == frame3)
                {
                    if (!sm.Selected)
                    {
                        if (One == null)
                            One = sm;
                        else if (Two == null)
                            Two = sm;
                        else if (Three == null)
                            Three = sm;
                        else
                            continue;
                    }
                }
            }
        }
    }

    void SkillChooser()
    {
        // #ȭ�鿡 �� ��ų 3���� Skill Num�� ���� ������ ���� �����ֱ�. �ߺ��� ���� ���� do while���� ����ߴ�.
        frame1 = Random.Range(MinValue, MaxValue + 1);
        do
            frame2 = Random.Range(MinValue, MaxValue + 1);
        while (frame2 != frame1);

        do
            frame3 = Random.Range(MinValue, MaxValue + 1);
        while (frame3 != frame2 && frame3 != frame1);

        do
        {
            foreach (Skill_Manager sm in scripts)
            {
                if (sm.Skill_Num == frame1 || sm.Skill_Num == frame2 || sm.Skill_Num == frame3)
                {
                    if (!sm.Selected)
                    {
                        if (One == null)
                            One = sm;
                        else if (Two == null)
                            Two = sm;
                        else if (Three == null)
                            Three = sm;
                        else
                            continue;
                    }
                }
            }
        }
        while (One == null || Two == null || Three == null);        //���� �� null�� �ƴ� ��ũ��Ʈ�� �Ҵ��� �Ǹ� �ݺ����� �������´�.    Update �Լ� �ȿ��� �̷��� �ݺ����� ������ �� �� �𸣰ڴ�.
        
    }
}

