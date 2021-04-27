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

        // # ��·�� Find�� ����ϴ� �ڵ嵵 �ᱹ�� ������. ���� ��ȯ�� ��� ������ ��� Ǯ��������. �ٸ� ����� ã�ƾ� �Ѵ�. 
        DontDestroyOnLoad(this);
       if(SceneManager.GetActiveScene().name == "Shelter")              //���� ���� ���Ͷ��
       {
            CopyShelter = GameObject.Find("Skill_System_In_Shelter");   //������ ��ų �ý��� ������Ʈ�� ������
            //SkillList = CopyShelter.GetComponent<Skill_Manager>().scripts.Clone();
            /*SkillIndex = new int[SkillList.Length];
            foreach (Skill_Manager sm in SkillList)*/   //�ϴ� ����
       }
       else                                                             //���� ���� ���Ͱ� �ƴ϶��
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
