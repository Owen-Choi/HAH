using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Skill_Choose : MonoBehaviour
{
    public GameObject Leg;  GameObject LegCache;
    public GameObject Arm;  GameObject ArmCache;
    public GameObject Chest;GameObject ChestCache;
    public GameObject Head; GameObject HeadCache;
    public GameObject Physic_System;
    Sprite[] ArmSprites;
    Sprite[] LegSprites;
    Sprite[] ChestSprites;
    Sprite[] HeadSprites;
    public int Min; public int Max;
    Physical_Manager One;
    Physical_Manager Two;
    bool ForOne;
    public GameObject Limitation;
    public GameObject LegIMG;
    public GameObject ArmIMG;
    public GameObject ChestIMG;
    public GameObject HeadIMG;
    public GameObject LegCurrent;
    public GameObject ArmCurrent;
    public GameObject ChestCurrent;
    public GameObject HeadCurrent;

    GameObject GMCache;
    private void Awake()
    {
        ForOne = false;
        ArmSprites = Resources.LoadAll<Sprite>("Arm_Physical_Skill");
        LegSprites = Resources.LoadAll<Sprite>("Leg_Physical_Skill");
        ChestSprites = Resources.LoadAll<Sprite>("Chest_Physical_Skill");
        HeadSprites = Resources.LoadAll<Sprite>("Head_Physical_Skill");

        GMCache = GameObject.Find("GameManager");

        LegCache = Leg;
        ArmCache = Arm;
        ChestCache = Chest;
        HeadCache = Head;
    }
    void Update()
    {
        if (LegCache.gameObject.activeSelf && !ForOne)
        {
            Min = 0;            // 이건 Skill_Num 값이다. 스프라이트와는 관계 없음.
            Max = 9;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            LegCurrent.gameObject.SetActive(true);
            // # 첫번째 버튼
            Leg.transform.GetChild(0).GetComponent<Image>().overrideSprite = LegSprites[One.Sprite_Num];
            Leg.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;                 //스킬의 이름을 UI에 띄워준다.
            Leg.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;                 //스킬의 설명을 UI에 띄워준다.
            // # 두번째 버튼
            Leg.transform.GetChild(1).GetComponent<Image>().overrideSprite = LegSprites[Two.Sprite_Num];
            Leg.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Leg.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
            LegIMG.gameObject.SetActive(true);
            Limitation.gameObject.SetActive(true);
            LegCurrent.GetComponent<Text>().text = Player_Stat.instance.LegLimit.ToString();
        }

        if (ArmCache.gameObject.activeSelf && !ForOne)
        {
            Min = 10;
            Max = 19;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            ArmCurrent.gameObject.SetActive(true);
            Arm.transform.GetChild(0).GetComponent<Image>().overrideSprite = ArmSprites[One.Sprite_Num];
            Arm.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;                
            Arm.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;               
            Arm.transform.GetChild(1).GetComponent<Image>().overrideSprite = ArmSprites[Two.Sprite_Num];
            Arm.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Arm.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
            ArmIMG.gameObject.SetActive(true);
            Limitation.gameObject.SetActive(true);
            ArmCurrent.GetComponent<Text>().text = Player_Stat.instance.ArmLimit.ToString();
        }

        if (ChestCache.gameObject.activeSelf && !ForOne)
        {
            Min = 20;
            Max = 32;   //갱신 예정
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            ChestCurrent.gameObject.SetActive(true);
            Chest.transform.GetChild(0).GetComponent<Image>().overrideSprite = ChestSprites[One.Sprite_Num];
            Chest.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;                 
            Chest.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;                 
            Chest.transform.GetChild(1).GetComponent<Image>().overrideSprite = ChestSprites[Two.Sprite_Num];
            Chest.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Chest.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
            ChestIMG.gameObject.SetActive(true);
            Limitation.gameObject.SetActive(true);
            ChestCurrent.GetComponent<Text>().text = Player_Stat.instance.ChestLimit.ToString();
        }

        if (HeadCache.gameObject.activeSelf && !ForOne)
        {
            Min = 35;
            Max = 45;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            HeadCurrent.gameObject.SetActive(true);
            Head.transform.GetChild(0).GetComponent<Image>().overrideSprite = HeadSprites[One.Sprite_Num];
            Head.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;
            Head.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;
            Head.transform.GetChild(1).GetComponent<Image>().overrideSprite = HeadSprites[Two.Sprite_Num];
            Head.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            Head.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            ForOne = true;
            HeadIMG.gameObject.SetActive(true);
            Limitation.gameObject.SetActive(true);
            HeadCurrent.GetComponent<Text>().text = Player_Stat.instance.HeadLimit.ToString();
        }
    }

    public void FirstButtonPress()
    {
        
        if (Leg.gameObject.activeSelf)
        {
            Leg.gameObject.SetActive(false);
            LegIMG.gameObject.SetActive(false);
            LegCurrent.gameObject.SetActive(false);
            Player_Stat.instance.LegLimit++;
        }
        else if (Arm.gameObject.activeSelf)
        {
            Arm.gameObject.SetActive(false);
            ArmIMG.gameObject.SetActive(false);
            ArmCurrent.gameObject.SetActive(false);
            Player_Stat.instance.ArmLimit++;
        }
        else if (Chest.gameObject.activeSelf)
        {
            Chest.gameObject.SetActive(false);
            ChestIMG.gameObject.SetActive(false);
            ChestCurrent.gameObject.SetActive(false);
            Player_Stat.instance.ChestLimit++;
        }
        else if (Head.gameObject.activeSelf)
        {
            Head.gameObject.SetActive(false);
            HeadIMG.gameObject.SetActive(false);
            HeadCurrent.gameObject.SetActive(false);
            Player_Stat.instance.HeadLimit++;
        }
        One.Selected = true;
        ForOne = false;

        Limitation.gameObject.SetActive(false);

        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        SaveSystem.SavePhysicalSkill();
        SaveSystem.SaveSkill();
        SaveSystem.SaveStat();
        SaveSystem.SaveItem();
    }

    public void SecondButtonPress()
    {
        
        if (Leg.gameObject.activeSelf)
        {
            Leg.gameObject.SetActive(false);
            LegIMG.gameObject.SetActive(false);
            LegCurrent.gameObject.SetActive(false);
            Player_Stat.instance.LegLimit++;
        }
        else if (Arm.gameObject.activeSelf)
        {
            Arm.gameObject.SetActive(false);
            ArmIMG.gameObject.SetActive(false);
            ArmCurrent.gameObject.SetActive(false);
            Player_Stat.instance.ArmLimit++;
        }
        else if (Chest.gameObject.activeSelf)
        {
            Chest.gameObject.SetActive(false);
            ChestIMG.gameObject.SetActive(false);
            ChestCurrent.gameObject.SetActive(false);
            Player_Stat.instance.ChestLimit++;
        }
        else if (Head.gameObject.activeSelf)
        {
            Head.gameObject.SetActive(false);
            HeadIMG.gameObject.SetActive(false);
            HeadCurrent.gameObject.SetActive(false);
            Player_Stat.instance.HeadLimit++;
        }
        Two.Selected = true;
        ForOne = false;

        Limitation.gameObject.SetActive(false);

        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        SaveSystem.SavePhysicalSkill();
        SaveSystem.SaveSkill();
        SaveSystem.SaveStat();
        SaveSystem.SaveItem();
    }
    IEnumerator WaitForUpdate()
    {
        yield return new WaitForEndOfFrame();
    }
}
