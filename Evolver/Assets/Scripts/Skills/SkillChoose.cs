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
        // # 더 나은 알고리즘이 있을 것이다.
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
        // #화면에 뜰 스킬 3개의 Skill Num을 난수 생성을 통해 정해주기. 중복을 막기 위해 do while문을 사용했다.
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
        while (One == null || Two == null || Three == null);        //세개 다 null이 아닌 스크립트가 할당이 되면 반복문을 빠져나온다.    Update 함수 안에서 이렇게 반복문을 돌려도 될 진 모르겠다.
        
    }
}

