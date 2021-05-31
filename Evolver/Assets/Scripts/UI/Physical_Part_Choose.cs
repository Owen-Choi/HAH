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
    // # ��ü���� ��ư 2�� ���� ����
    void Start()
    {
        Physic_ChooseUI.gameObject.SetActive(false);        // �ϴ��� ������Ʈ ���α�
        ArmSprites = Resources.LoadAll<Sprite>("Arm_Physical_Skill");
        LegSprites = Resources.LoadAll<Sprite>("Leg_Physical_Skill");
        ChestSprites = Resources.LoadAll<Sprite>("Chest_Physical_Skill");
        HeadSprites = Resources.LoadAll<Sprite>("Head_Physical_Skill");
        ForOne = false;
    }

    // # 1 : �ٸ� 2 : �� 3 : ���� 4 : �Ӹ� 
    void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp)
        {
            Player_Stat.instance.isPhysical_LevelUp = false;
            Physic_ChooseUI.gameObject.SetActive(true);
            randNum1 = Random.Range(1, 5);
            do
                randNum2 = Random.Range(1, 5);
            while (randNum1 == randNum2);               //�ΰ��� ���� ���� �� ����.
            switch(randNum1)
            {
                
                case 1:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = ArmSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Arm";                                                //�̸��� ǥ�õǴ� UI
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Damage, Charging speed, Arrow speed";               //������ ǥ�õǴ� UI
                    break;
                case 2:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = LegSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Leg";
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Movement speed, Dodge";
                    break;
                case 3:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = ChestSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Chest";
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Armor, Health, Stamina";
                    break;
                case 4:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = HeadSprites[0];
                    Physic_ChooseUI.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Head";
                    Physic_ChooseUI.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Critical chance, Critical damage";
                    break;
                default:
                    Debug.Log("Error in body part choose");
                    break;
            }
            switch (randNum2)
            {
                case 1:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = ArmSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Arm";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "Damage, Charging speed, Arrow speed";
                    break;
                case 2:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = LegSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Leg";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "Movement speed, Dodge";
                    break;
                case 3:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = ChestSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Chest";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "Armor, Health, Stamina";
                    break;
                case 4:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = HeadSprites[0];
                    Physic_ChooseUI.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Head";
                    Physic_ChooseUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "Critical chance, Critical damage";
                    break;
                default:
                    Debug.Log("Error in body part choose");
                    break;
            }
            // # �ΰ��� ������ ���ؼ� ��������Ʈ �̹����� ������ �Ѱ��־�� �Ѵ�.
        }   
    }
    public void FirstButtonPressed()
    {
        switch (randNum1)
        {
            case 1:
                {
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Arm.gameObject.SetActive(true);             //Leg_Skills UI���� ��ų �������� ������� �� �ٷ���� �� ����. ��ư�� �������� �� �̻� ���� ������ ��ų�� ������ ����δ� �������� ����.
                    break;
                }
            case 2:
                {
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Leg.gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Chest.gameObject.SetActive(true);
                    break;
                }
            case 4:
                {
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
                Physic_ChooseUI.gameObject.SetActive(false);
                Arm.gameObject.SetActive(true);
                break;
            case 2:
                Physic_ChooseUI.gameObject.SetActive(false);
                Leg.gameObject.SetActive(true);
                break;
            case 3:
                Physic_ChooseUI.gameObject.SetActive(false);
                Chest.gameObject.SetActive(true);
                break;
            case 4:
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
