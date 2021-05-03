using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillChoose : MonoBehaviour
{
    bool ForOne;    public bool isPressed;
    public Canvas SkillChooseUI;
    public GameObject Skill_Manager;
    string spriteName;
    public int MinValue;   public int MaxValue;
    Skill_Manager One;
    Skill_Manager Two;
    Skill_Manager Three;
    Sprite[] sprites;
    private void Start()
    {

        SkillChooseUI.gameObject.SetActive(false);

        sprites = Resources.LoadAll<Sprite>("SkillIcon");
        ForOne = false;
    }

    private void Update()
    {
        // # Skill_Manager���� �Ѱ��� ������ �޾� ��ư�� ����.
        if (Player_Stat.instance.isLevelUp && !ForOne)
        {
            One = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(1);
            Two = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(2);
            Three = Skill_Manager.GetComponent<Skill_Manager>().LevelUpSkillChoose(3);
            SkillChooseUI.gameObject.SetActive(true);
            //Obj.transform.GetChild(0).GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>("Textures/sprite"); ���� �ڵ�
            spriteName = "SkillIcon_" + One.Sprite_Num;
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
            return;             //���� ��Ȳ�� ����ϴ� �ڵ� �����غ���
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

