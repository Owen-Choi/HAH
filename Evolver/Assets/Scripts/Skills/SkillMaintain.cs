using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkillMaintain : MonoBehaviour
{
   
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
        DontDestroyOnLoad(this);
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
            // # SkillList�� ������ �ٽ� ����ü�� �־��ش�.
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

        // # ���� �����鼭 ������ �� �ִ� ����� �ֳ�?

        if(SceneManager.GetActiveScene().name == "Shelter" && GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed)              
        {
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed = false;
            StructIndex = 0;
            // # SkillList�� ������ �ٽ� ����ü�� �־��ش�.
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

        if(SceneManager.GetActiveScene().name != "Shelter" && !forTwo)
        {
            StructIndex = 0;
            forTwo = true;
            foreach (Skill_Manager sm in GameObject.Find("Skill_System_In_Map").GetComponent<Skill_Manager>().scripts)
            {
                if (container[StructIndex].Selected_Second)
                {
                    sm.Selected_First = true;
                    sm.Selected_Second = true;
                }
                else if (container[StructIndex].Selected)
                {
                    sm.Selected = true;
                }
                else if (container[StructIndex].Selected_First)
                {
                    sm.Selected_First = true;
                }
                StructIndex++;
            }


        }

        // # ������ ��ų�� �� ��ȯ �� �ʱ�ȭ�� �Ǿ� ���� ���̴�. �� ������ �ٽ� ���Ϳ� �־���� �ϴµ�....
        if((SceneManager.GetActiveScene().name == "Shelter" && !forThree)) 
        {
            StructIndex = 0;
            forThree = true;
            while(StructIndex < SkillList.Length)
            {
                Debug.Log("Yeah");
                if (container[StructIndex].Selected_Second)
                {
                    
                    SkillList[StructIndex].Selected_First = true;
                    SkillList[StructIndex].Selected_Second = true;
                }
                else if (container[StructIndex].Selected)
                {
                    SkillList[StructIndex].Selected = true;
                }
                else if (container[StructIndex].Selected_First)
                {
                    SkillList[StructIndex].Selected_First = true;
                }
                StructIndex++;
            }
        }
    }
}
