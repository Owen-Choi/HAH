using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkillMaintain : MonoBehaviour
{
   
    // # ���� �������̴� ������ ��Ŀ��� �� ���� ��ų�� �����ϱ� ���� ������� ��ũ��Ʈ. ���翡�� �ƹ� ��ɵ� ���� �ʴ´�. 

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

        if(GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed)              
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

       
    }
}
