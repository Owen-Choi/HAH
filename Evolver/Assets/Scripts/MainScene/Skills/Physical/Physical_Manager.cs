using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physical_Manager : MonoBehaviour
{
    public int Skill_Num;
    public int Sprite_Num;
    public Physical_Manager[] scripts;
    public bool Selected;
    public string Skill_Name;
    public string Skill_Desc;
    
    void Start()
    {
        scripts = this.GetComponents<Physical_Manager>();
        this.Selected = false;
    }
    /*void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp)
        {
            
        }
    }*/

    public Physical_Manager Physic_Skill_Choose(int Min, int Max, int num)
    {
        int frame1; int frame2;
        Physical_Manager chosen1 = null; Physical_Manager chosen2 = null;
        StartCoroutine("LevelUpDelay");
        frame1 = Random.Range(Min, Max + 1);
        do
        {
            frame2 = Random.Range(Min, Max + 1);
        }
        while (frame2 == frame1);

        foreach (Physical_Manager pm in scripts)
        {
            if (pm.Skill_Num == frame1)
                chosen1 = pm;
            if (pm.Skill_Num == frame2)
                chosen2 = pm;
        }
        // # 중복이 발생할 수 있는 잘못된 코드이다.
        if (num == 1)
            return chosen1;
        else if (num == 2)
            return chosen2;
        else
            return null;

    }

    IEnumerator LevelUpDelay()
    {
        yield return new WaitForEndOfFrame();
    }
}
