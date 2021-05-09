using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Part_Choose : MonoBehaviour
{
    public GameObject Physic_ChooseUI;
    bool ForOne;
    int randNum1;   int randNum2;
   // # 신체부위 버튼 2개 먼저 띄우기
    void Start()
    {
        Physic_ChooseUI.gameObject.SetActive(false);        // 일단은 오브젝트 꺼두기
        
    }

    // # 1 : 다리 2 : 팔 3 : 가슴 4 : 머리 
    void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp && !ForOne)
        {
            randNum1 = Random.Range(1, 5);
            do
                randNum2 = Random.Range(1, 5);
            while (randNum1 == randNum2);               //두개의 수는 같을 수 없다.
            if(randNum1 == 1)
            {
                 
            }
            // # 두개의 부위를 정해서 스프라이트 이미지와 정보를 넘겨주어야 한다.
            Physic_ChooseUI.gameObject.SetActive(true);
        }   
    }

    IEnumerator Physical_LevelUp_Delay()
    {
        yield return new WaitForEndOfFrame();
        Player_Stat.instance.isPhysical_LevelUp = false;
        ForOne = false;
    }
}
