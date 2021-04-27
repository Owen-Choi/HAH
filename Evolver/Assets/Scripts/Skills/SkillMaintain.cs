using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkillMaintain : MonoBehaviour
{
    public GameObject CopyShelter;
    Skill_Manager tempSkillManager;
    public Skill_Manager[] SkillList;
    bool forOne;
    void Start()
    {

        // # 어쨌든 Find를 사용하는 코드도 결국엔 참조다. 씬이 전환될 경우 참조가 모두 풀려버린다. 다른 방법을 찾아야 한다. 
        DontDestroyOnLoad(this);
       if(SceneManager.GetActiveScene().name == "Shelter")              //현재 씬이 쉘터라면
       {
            CopyShelter = GameObject.Find("Skill_System_In_Shelter");   //쉘터의 스킬 시스템 오브젝트를 복사함
            //SkillList = CopyShelter.GetComponent<Skill_Manager>().scripts.Clone();
            /*SkillIndex = new int[SkillList.Length];
            foreach (Skill_Manager sm in SkillList)*/   //일단 보류
       }
       else                                                             //현재 씬이 쉘터가 아니라면
       {
            GameObject.Find("Skill_System_In_Map").GetComponent<Skill_Manager>().scripts = SkillList;       
            Debug.Log("bye there");
       }
        forOne = false;
    }

    private void Update()
    {
        if(Player_Stat.instance.isLevelUp)
        {
            CopyShelter = GameObject.Find("Skill_System_In_Shelter");
            SkillList = CopyShelter.GetComponent<Skill_Manager>().scripts;
        }

        if(SceneManager.GetActiveScene().name != "Shelter" && !forOne)
        {
            forOne = true;
            GameObject.Find("Skill_System_In_Map").GetComponent<Skill_Manager>().scripts = SkillList;      
            Debug.Log("bye there");
        }
    }
}
