using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChoose : MonoBehaviour
{
    public GameObject WeaponChoose;
    Skill_Manager One;   public int frame1;
    Skill_Manager Two;   public int frame2;
    Skill_Manager Three; public int frame3;
    public Skill_Manager[] scripts;
    public int MinValue;   public int MaxValue;

    private void Awake()
    {

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

   /* void Update()
    {
        if (Player_Stat.instance.isLevelUp)
        {
            Player_Stat.instance.isLevelUp = false;
            frame1 = Random.Range(MinValue, MaxValue + 1);
            do
                frame2 = Random.Range(MinValue, MaxValue + 1);
            while (frame2 == frame1);

            do
                frame3 = Random.Range(MinValue, MaxValue + 1);
            while (frame3 == frame2 || frame3 == frame1);

        }
    }*/

   
}

