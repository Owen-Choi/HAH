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
    Sprite[] sprites;
    public Canvas Leg;
    public Canvas Arm;
    public Canvas Chest;
    public Canvas Head;
    // # ��ü���� ��ư 2�� ���� ����
    void Start()
    {
        Physic_ChooseUI.gameObject.SetActive(false);        // �ϴ��� ������Ʈ ���α�
        sprites = Resources.LoadAll<Sprite>("Physical_Skill");
        ForOne = false;
    }

    // # 1 : �ٸ� 2 : �� 3 : ���� 4 : �Ӹ� 
    void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp && !ForOne)
        {
            ForOne = true;
            Physic_ChooseUI.gameObject.SetActive(true);
            randNum1 = Random.Range(1, 5);
            do
                randNum2 = Random.Range(1, 5);
            while (randNum1 == randNum2);               //�ΰ��� ���� ���� �� ����.
            switch(randNum1)
            {
                case 1:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[8];
                    break;
                case 2:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[0];
                    break;
                case 3:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[14];
                    break;
                case 4:
                    Physic_ChooseUI.transform.GetChild(0).GetComponent<Image>().overrideSprite = sprites[19];
                    break;
                default:
                    Debug.Log("Error in body part choose");
                    break;
            }
            switch (randNum2)
            {
                case 1:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[8];
                    break;
                case 2:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[0];
                    break;
                case 3:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[14];
                    break;
                case 4:
                    Physic_ChooseUI.transform.GetChild(1).GetComponent<Image>().overrideSprite = sprites[19];
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
                    Leg.gameObject.SetActive(true);             //Leg_Skills UI���� ��ų �������� ������� �� �ٷ���� �� ����. ��ư�� �������� �� �̻� ���� ������ ��ų�� ������ ����δ� �������� ����.
                    break;
                }
            case 2:
                {
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Arm.gameObject.SetActive(true);
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
                Leg.gameObject.SetActive(true);
                break;
            case 2:
                Physic_ChooseUI.gameObject.SetActive(false);
                Arm.gameObject.SetActive(true);
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
        Player_Stat.instance.isPhysical_LevelUp = false;
        ForOne = false;
    }
}
