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
    Sprite[] sprites;
    [HideInInspector]
    public int Min; public int Max;
    Physical_Manager One;
    Physical_Manager Two;
    bool ForOne;
    private void Awake()
    {
        ForOne = false;
        sprites = Resources.LoadAll<Sprite>("Physical_Skill");
    }
    void Update()
    {
        if (Leg.gameObject.activeSelf && !ForOne)
        {
            Min = 0;
            Max = 5;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Leg.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[One.Sprite_Num];
            Leg.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[Two.Sprite_Num];
            ForOne = true;
        }

        if (Arm.gameObject.activeSelf && !ForOne)
        {
            Min = 10;
            Max = 16;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Arm.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[One.Sprite_Num];
            Arm.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[Two.Sprite_Num];
            ForOne = true;
        }

        if (Chest.gameObject.activeSelf && !ForOne)
        {
            Min = 20;
            Max = 28;   //갱신 예정
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Chest.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[One.Sprite_Num];
            Chest.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[Two.Sprite_Num];
            ForOne = true;
        }

        if (Head.gameObject.activeSelf && !ForOne)
        {
            Min = 35;
            Max = 43;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(Min, Max, 2);
            Head.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[One.Sprite_Num];
            Head.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[Two.Sprite_Num];
            ForOne = true;
        }
    }
    IEnumerator WaitForUpdate()
    {
        yield return new WaitForEndOfFrame();
    }
}
