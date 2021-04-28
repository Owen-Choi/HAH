using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillChoose : MonoBehaviour
{
    bool ForOne;    public bool isPressed;
    public Canvas SkillChooseUI;
    public GameObject Skill_Manager;
    public GameObject WeaponChoose;
    string spriteName;
    public int MinValue;   public int MaxValue;
    Skill_Manager One;
    Skill_Manager Two;
    Skill_Manager Three;
    Sprite[] sprites;
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

        SkillChooseUI.gameObject.SetActive(false);

        sprites = Resources.LoadAll<Sprite>("SkillIcon");
        ForOne = false;
    }

    private void Update()
    {
        if (Player_Stat.instance.isLevelUp && !ForOne)
        {
            One = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(1);
            Two = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(2);
            Three = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(3);
            Debug.Log(One); Debug.Log(Two); Debug.Log(Three);
            SkillChooseUI.gameObject.SetActive(true);
            //Obj.transform.GetChild(0).GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>("Textures/sprite"); 예제 코드
            spriteName = "SkillIcon_" + One.Sprite_Num;
            Debug.Log(spriteName);
            //SkillChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(spriteName);
            SkillChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[One.Sprite_Num];
            spriteName = "SkillIcon_" + Two.Sprite_Num;
            SkillChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[Two.Sprite_Num];
            spriteName = "SkillIcon_" + Three.Sprite_Num;
            SkillChooseUI.transform.GetChild(2).GetComponent<Image>().overrideSprite = sprites[Three.Sprite_Num];
            ForOne = true;
            StartCoroutine("LevelUpDelay");
        }
    }

    // # Selected 된 스킬은 아예 목록에 뜨지 않는다. 따라서 Selected_First, Second, Last 이 세가지만 신경쓰면 됨.
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
    }
    IEnumerator LevelUpDelay()
    {
        yield return new WaitForEndOfFrame();
        Player_Stat.instance.isLevelUp = false;
        ForOne = false;
    }
}

