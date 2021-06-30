using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChoose : MonoBehaviour
{
    bool ForOne; public bool isPressed;
    public Canvas SkillChooseUI;
    public GameObject Skill_Manager;
    string spriteName;
    public int MinValue; public int MaxValue;
    Skill_Manager One;
    Skill_Manager Two;
    Skill_Manager Three;
    public Sprite[] sprites;
    public GameObject BackPack;
    public GameObject GameManager;
    GameObject GMCache;
    private void Start()
    {
        SkillChooseUI.gameObject.SetActive(false);
        // # 스프라이트를 Resources 파일에서 가져오는 작업은 WeaponChoose 스크립트에서 진행한다.
        ForOne = false;
        GMCache = GameManager;
    }

    private void Update()
    {
        // # Skill_Manager에서 넘겨준 정보를 받아 버튼에 띄운다.
        if (Player_Stat.instance.isLevelUp && !ForOne)                                  // isLevelUp이 true로 바뀐다면 
        {
            One = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(1);
            Two = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(2);
            Three = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(3);
            SkillChooseUI.gameObject.SetActive(true);
            //Obj.transform.GetChild(0).GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>("Textures/sprite"); 예제 코드
            spriteName = "SkillIcon_" + One.Sprite_Num;
            //SkillChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(spriteName);

            SkillChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[One.Sprite_Num];
            SkillChooseUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = One.Skill_Name;
            SkillChooseUI.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = One.Skill_Desc;
            spriteName = "SkillIcon_" + Two.Sprite_Num;
            SkillChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[Two.Sprite_Num];
            SkillChooseUI.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Two.Skill_Name;
            SkillChooseUI.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Two.Skill_Desc;
            spriteName = "SkillIcon_" + Three.Sprite_Num;
            SkillChooseUI.transform.GetChild(2).GetComponent<Image>().overrideSprite = sprites[Three.Sprite_Num];
            SkillChooseUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Three.Skill_Name;
            SkillChooseUI.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = Three.Skill_Desc;
            ForOne = true;
            StartCoroutine("LevelUpDelay");
        }
    }


    public void FirstButtonPressed()
    {
        if (!One.Selected_First)
            One.Selected_First = true;
        else if (!One.Selected_Second)
            One.Selected_Second = true;
        else if (!One.Selected_Last)
            One.Selected_Last = true;
        else
        {
            Debug.Log("Error in One");
            return;             //오류 상황에 대비하는 코드 생각해보기
        }
        SkillChooseUI.gameObject.SetActive(false);
        isPressed = true;
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        Player_Stat.instance.SkillLimit++;
        SaveSystem.SaveStat();
        SaveSystem.SavePhysicalSkill();
        SaveSystem.SaveItem();
        SaveSystem.SaveSkill();
    }
    public void SecondButtonPressed()
    {
        if (!Two.Selected_First)
            Two.Selected_First = true;
        else if (!Two.Selected_Second)
            Two.Selected_Second = true;
        else if (!Two.Selected_Last)
            Two.Selected_Last = true;
        else
        {
            Debug.Log("Error in Two");
            return;
        }
        SkillChooseUI.gameObject.SetActive(false);
        isPressed = true;
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        Player_Stat.instance.SkillLimit++;
        SaveSystem.SaveSkill();
        SaveSystem.SaveItem();
        SaveSystem.SaveStat();
        SaveSystem.SavePhysicalSkill();
    }
    public void ThirdButtonPressed()
    {
        if (!Three.Selected_First)
            Three.Selected_First = true;
        else if (!Three.Selected_Second)
            Three.Selected_Second = true;
        else if (!Three.Selected_Last)
            Three.Selected_Last = true;
        else
        {
            Debug.Log("Error in Three");
            return;
        }
        SkillChooseUI.gameObject.SetActive(false);
        isPressed = true;
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        Player_Stat.instance.SkillLimit++;
        SaveSystem.SaveSkill();
        SaveSystem.SaveItem();
        SaveSystem.SaveStat();
        SaveSystem.SavePhysicalSkill();
    }

    public void CancelButton()
    {
        BackPack.GetComponent<BackPack>().AddItem("MutantSample", 5);
        SkillChooseUI.gameObject.SetActive(false);
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        Time.timeScale = 1f;
        SaveSystem.SaveSkill();
        SaveSystem.SaveItem();
        SaveSystem.SaveStat();
        SaveSystem.SavePhysicalSkill();
    }

    IEnumerator LevelUpDelay()                          //혹시 몰라 약간의 간격을 주기 위해 만들어 둔 딜레이
    {
        yield return new WaitForEndOfFrame();
        Player_Stat.instance.isLevelUp = false;
        ForOne = false;
    }
}

