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
    // # 신체부위 버튼 2개 먼저 띄우기
    void Start()
    {
        Physic_ChooseUI.gameObject.SetActive(false);        // 일단은 오브젝트 꺼두기
        sprites = Resources.LoadAll<Sprite>("Physical_Skill");
        ForOne = false;
    }

    // # 1 : 다리 2 : 팔 3 : 가슴 4 : 머리 
    void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp && !ForOne)
        {
            ForOne = true;
            Physic_ChooseUI.gameObject.SetActive(true);
            randNum1 = Random.Range(1, 5);
            do
                randNum2 = Random.Range(1, 5);
            while (randNum1 == randNum2);               //두개의 수는 같을 수 없다.
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
            // # 두개의 부위를 정해서 스프라이트 이미지와 정보를 넘겨주어야 한다.
        }   
    }
    public void FirstButtonPressed()
    {
        switch (randNum1)
        {
            case 1:
                {
                    Physic_ChooseUI.gameObject.SetActive(false);
                    Leg.gameObject.SetActive(true);             //Leg_Skills UI에서 스킬 선정부터 적용까지 다 다뤄야할 것 같다. 버튼을 기준으로 더 이상 투자 가능한 스킬이 없으면 비워두는 형식으로 가자.
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
