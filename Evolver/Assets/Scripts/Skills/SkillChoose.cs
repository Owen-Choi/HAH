using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillChoose : MonoBehaviour
{
    public Canvas SkillChooseUI;
    public GameObject Skill_Manager;
    public GameObject WeaponChoose;
    public int MinValue;   public int MaxValue;
    Skill_Manager One;
    Skill_Manager Two;
    Skill_Manager Three;
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

            SkillChooseUI.gameObject.SetActive(true);
            //Obj.transform.GetChild(0).GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>("Textures/sprite"); 예제 코드
        }
    }
    IEnumerator LevelUpDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }
}

