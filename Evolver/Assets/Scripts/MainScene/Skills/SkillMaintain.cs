using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkillMaintain : MonoBehaviour
{
   
    // # 씬이 여러개이던 기존의 방식에서 씬 간에 스킬을 연동하기 위해 만들었던 스크립트. 현재에는 아무 기능도 하지 않는다. 

    Skill_Manager tempSkillManager;
    public Skill_Manager[] SkillList;
    bool forOne;    int StructIndex;
    bool forTwo;    bool forThree;

    public struct SkillContainer
    {
        public bool Selected_First;
        public bool Selected_Second;
        public bool Selected_Last;
        public bool Selected;
    }

    SkillContainer[] container;
    //SkillContainer[] containerForShelter;
    void Awake()
    {
        container = new SkillContainer[30];
        //SkillList =  GameObject.Find("Skill_System_In_Shelter").GetComponents<Skill_Manager>();
        forOne = false;
        forTwo = false;
        Debug.Log("Start");
    }

    private void Update()
    {

        if (!forOne)
        {
            forOne = true;
            SkillList = (Skill_Manager[])GameObject.Find("Skill_System_In_Shelter").GetComponent<Skill_Manager>().scripts.Clone();
            StructIndex = 0;
            // # SkillList의 정보를 다시 구조체에 넣어준다.
            foreach (Skill_Manager sm in SkillList)
            {
                if (sm.Selected)
                {
                    container[StructIndex].Selected = true;
                    continue;
                }
                else if (sm.Selected_Second)
                {
                    container[StructIndex].Selected_First = container[StructIndex].Selected_Second = true;
                    continue;
                }
                else if (sm.Selected_First)
                {
                    container[StructIndex].Selected_First = true;
                    continue;
                }
                StructIndex++;
            }

        }

        // # 씬을 나가면서 실행할 수 있는 방법이 있나?

        if(GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed)              
        {
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed = false;
            StructIndex = 0;
            // # SkillList의 정보를 다시 구조체에 넣어준다.
            foreach (Skill_Manager sm in GameObject.Find("Skill_System_In_Shelter").GetComponent<Skill_Manager>().scripts)          
            {
                if (sm.Selected)
                {
                    container[StructIndex].Selected = true;
                    continue;
                }
                else if (sm.Selected_Second)
                {
                    container[StructIndex].Selected_First = container[StructIndex].Selected_Second = true;
                    continue;
                }
                else if (sm.Selected_First)
                {
                    container[StructIndex].Selected_First = true;
                    continue;
                }
                StructIndex++;
            }
        }

       
    }
}
