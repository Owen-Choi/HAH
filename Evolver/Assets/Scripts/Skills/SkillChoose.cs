using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillChoose : MonoBehaviour
{
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
    }

    private void Update()
    {
        if (Player_Stat.instance.isLevelUp)
        {
            Player_Stat.instance.isLevelUp = false;
            StartCoroutine("LevelUpDelay");
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
        }
    }
    IEnumerator LevelUpDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }
}

