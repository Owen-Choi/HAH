using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Skill_Choose : MonoBehaviour
{
    public GameObject Leg;
    public GameObject Arm;
    public GameObject Chest;
    public GameObject Head;
    public GameObject Physic_System;
    Sprite[] ArmSprites;
    Sprite[] LegSprites;
    Sprite[] ChestSprites;
    Sprite[] HeadSprites;
    public int Min; public int Max;
    Physical_Manager One;
    Physical_Manager Two;
    bool ForOne;

    GameObject GMCache;
    private void Awake()
    {
        ForOne = false;
        ArmSprites = Resources.LoadAll<Sprite>("Arm_Physical_Skill");
        LegSprites = Resources.LoadAll<Sprite>("Leg_Physical_Skill");
        ChestSprites = Resources.LoadAll<Sprite>("Chest_Physical_Skill");
        HeadSprites = Resources.LoadAll<Sprite>("Head_Physical_Skill");

        GMCache = GameObject.Find("GameManager");
    }
    void Update()
    {
        if (Leg.gameObject.activeSelf && !ForOne)
        {
            Min = 0;            // 이건 Skill_Num 값이다. 스프라이트와는 관계 없음.
            Max = 5;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            // # 첫번째 버튼
            Leg.transform.GetChild(0).GetComponent<Image>().overrideSprite = LegSprites[One.Sprite_Num];
            Leg.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;                 //스킬의 이름을 UI에 띄워준다.
            Leg.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;                 //스킬의 설명을 UI에 띄워준다.
            // # 두번째 버튼
            Leg.transform.GetChild(1).GetComponent<Image>().overrideSprite = LegSprites[Two.Sprite_Num];
            Leg.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Leg.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
        }

        if (Arm.gameObject.activeSelf && !ForOne)
        {
            Min = 10;
            Max = 16;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Arm.transform.GetChild(0).GetComponent<Image>().overrideSprite = ArmSprites[One.Sprite_Num];
            Arm.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;                
            Arm.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;               
            Arm.transform.GetChild(1).GetComponent<Image>().overrideSprite = ArmSprites[Two.Sprite_Num];
            Arm.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Arm.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
        }

        if (Chest.gameObject.activeSelf && !ForOne)
        {
            Min = 20;
            Max = 28;   //갱신 예정
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Chest.transform.GetChild(0).GetComponent<Image>().overrideSprite = ChestSprites[One.Sprite_Num];
            Chest.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;                 
            Chest.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;                 
            Chest.transform.GetChild(1).GetComponent<Image>().overrideSprite = ChestSprites[Two.Sprite_Num];
            Chest.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Chest.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
        }

        if (Head.gameObject.activeSelf && !ForOne)
        {
            Min = 35;
            Max = 43;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Head.transform.GetChild(0).GetComponent<Image>().overrideSprite = HeadSprites[One.Sprite_Num];
            Head.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;
            Head.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;
            Head.transform.GetChild(1).GetComponent<Image>().overrideSprite = HeadSprites[Two.Sprite_Num];
            Head.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Head.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
        }
    }

    public void FirstButtonPress()
    {
        One.Selected = true;
        if (Leg.gameObject.activeSelf)
            Leg.gameObject.SetActive(false);
        else if (Arm.gameObject.activeSelf)
            Arm.gameObject.SetActive(false);
        else if (Chest.gameObject.activeSelf)
            Chest.gameObject.SetActive(false);
        else if (Head.gameObject.activeSelf)
            Head.gameObject.SetActive(false);
        ForOne = false;

        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        SaveSystem.SavePhysicalSkill();
    }

    public void SecondButtonPress()
    {
        Two.Selected = true;
        if (Leg.gameObject.activeSelf)
            Leg.gameObject.SetActive(false);
        else if (Arm.gameObject.activeSelf)
            Arm.gameObject.SetActive(false);
        else if (Chest.gameObject.activeSelf)
            Chest.gameObject.SetActive(false);
        else if (Head.gameObject.activeSelf)
            Head.gameObject.SetActive(false);
        ForOne = false;

        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        SaveSystem.SavePhysicalSkill();
    }
    IEnumerator WaitForUpdate()
    {
        yield return new WaitForEndOfFrame();
    }
}
