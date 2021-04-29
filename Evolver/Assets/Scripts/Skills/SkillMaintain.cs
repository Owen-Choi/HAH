using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkillMaintain : MonoBehaviour
{
   
    Skill_Manager tempSkillManager;
    public Skill_Manager[] SkillList;
    bool forOne;    int StructIndex;
    bool forTwo;

    public struct SkillContainer
    {
        public bool Selected_First;
        public bool Selected_Second;
        public bool Selected_Last;
        public bool Selected;
    }

    SkillContainer[] container;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Shelter")
        {
            var obj = FindObjectsOfType<SkillMaintain>();
            if (obj.Length <= 2)
                DontDestroyOnLoad(this);
            else
                Destroy(this.gameObject);
        }
        container = new SkillContainer[30];
        SkillList =  GameObject.Find("Skill_System_In_Shelter").GetComponents<Skill_Manager>();
        forOne = false;
        forTwo = false;
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

        if(SceneManager.GetActiveScene().name == "Shelter" && GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed)              
        {
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().isPressed = false;
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
    }
}
