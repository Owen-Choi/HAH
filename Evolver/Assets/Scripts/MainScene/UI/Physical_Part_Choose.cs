using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Part_Choose : MonoBehaviour
{
    public GameObject Physic_ChooseUI;
    public 
    bool ForOne;
    int randNum1;   int randNum2;
    Sprite[] ArmSprites;
    Sprite[] LegSprites;
    Sprite[] ChestSprites;
    Sprite[] HeadSprites;
    public Canvas Leg;
    public Canvas Arm;
    public Canvas Chest;
    public Canvas Head;
    public Text Limit_Guide;
    // # 신체부위 버튼 2개 먼저 띄우기
    void Start()
    {
        Physic_ChooseUI.gameObject.SetActive(false);        // 일단은 오브젝트 꺼두기
        ArmSprites = Resources.LoadAll<Sprite>("Arm_Physical_Skill");
        LegSprites = Resources.LoadAll<Sprite>("Leg_Physical_Skill");
        ChestSprites = Resources.LoadAll<Sprite>("Chest_Physical_Skill");
        HeadSprites = Resources.LoadAll<Sprite>("Head_Physical_Skill");
        ForOne = false;
    }

    // # 1 : 다리 2 : 팔 3 : 가슴 4 : 머리 
    void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp)
        {
            Player_Stat.instance.isPhysical_LevelUp = false;
            Physic_ChooseUI.gameObject.SetActive(true);
            randNum1 = Random.Range(1, 5);
            do
                randNum2 = Random.Range(1, 5);
            while (randNum1 == randNum2);               //두개의 수는 같을 수 없다.
            switch(randNum1)
            {
                
                case 1:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = ArmSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "팔";                                                //이름이 표시되는 UI
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "공격력, 차징 속도, 투사체 속도";                    //설명이 표시되는 UI
                    break;
                case 2:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = LegSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "다리";
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "이동속도, 회피율";
                    break;
                case 3:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = ChestSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "가슴";
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "방어력, 체력, 스테미나";
                    break;
                case 4:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = HeadSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "머리";
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "치명타 확률, 치명타 피해량";
                    break;
                default:
                    Debug.Log("Error in body part choose");
                    break;
            }
            switch (randNum2)
            {
                case 1:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = ArmSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "팔";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "공격력, 차징 속도, 투사체 속도";
                    break;
                case 2:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = LegSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "다리";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "이동속도, 회피율";
                    break;
                case 3:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = ChestSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "가슴";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "방어력, 체력, 스테미나";
                    break;
                case 4:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = HeadSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "머리";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "치명타 확률, 치명타 피해량";
                    break;
                default:
                    Debug.Log("Error in body part choose");
                    break;
            }
            // # 두개의 부위를 정해서 스프라이트 이미지와 정보를 넘겨주어야 한다.
        }   
    }
    public void FirstButtonPressed()
    {
        switch (randNum1)
        {
            case 1:
                {
                    if(Player_Stat.instance.ArmLimit >= 10)
                    {
                        Limit_Guide.gameObject.SetActive(true);
                        break;
                    }
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Arm.gameObject.SetActive(true);             //Leg_Skills UI에서 스킬 선정부터 적용까지 다 다뤄야할 것 같다. 버튼을 기준으로 더 이상 투자 가능한 스킬이 없으면 비워두는 형식으로 가자.
                    break;
                }
            case 2:
                {
                    if (Player_Stat.instance.LegLimit >= 10)
                    {
                        Limit_Guide.gameObject.SetActive(true);
                        break;
                    }
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Leg.gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    if (Player_Stat.instance.ChestLimit >= 10)
                    {
                        Limit_Guide.gameObject.SetActive(true);
                        break;
                    }
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Chest.gameObject.SetActive(true);
                    break;
                }
            case 4:
                {
                    if (Player_Stat.instance.HeadLimit >= 10)
                    {
                        Limit_Guide.gameObject.SetActive(true);
                        break;
                    }
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Head.gameObject.SetActive(true);
                    break;
                }
            default:
                Debug.Log("Error in body part choose");
                break;
        }
    }
    public void SecondButtonPressed()
    {
        switch (randNum2)
        {
            case 1:
                if (Player_Stat.instance.ArmLimit >= 10)
                {
                    Limit_Guide.gameObject.SetActive(true);
                    break;
                }
                Physic_ChooseUI.gameObject.SetActive(false);
                Arm.gameObject.SetActive(true);
                break;
            case 2:
                if (Player_Stat.instance.LegLimit >= 10)
                {
                    Limit_Guide.gameObject.SetActive(true);
                    break;
                }
                Physic_ChooseUI.gameObject.SetActive(false);
                Leg.gameObject.SetActive(true);
                break;
            case 3:
                if (Player_Stat.instance.ChestLimit >= 10)
                {
                    Limit_Guide.gameObject.SetActive(true);
                    break;
                }
                Physic_ChooseUI.gameObject.SetActive(false);
                Chest.gameObject.SetActive(true);
                break;
            case 4:
                if (Player_Stat.instance.HeadLimit >= 10)
                {
                    Limit_Guide.gameObject.SetActive(true);
                    break;
                }
                Physic_ChooseUI.gameObject.SetActive(false);
                Head.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Error in body part choose");
                break;
        }
    }

    IEnumerator Physical_LevelUp_Delay()
    {
        yield return new WaitForEndOfFrame();
    }
}
