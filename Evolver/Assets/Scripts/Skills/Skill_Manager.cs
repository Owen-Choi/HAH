using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour {
    public int Skill_Num;
    public bool Selected;

    public bool Selected_First;
    public bool Selected_Second;
    public bool Selected_Last;
    Skill_Manager[] scripts;
    private void Start()
    {
        scripts = this.GetComponents<Skill_Manager>();
    }

    public virtual void Activate_First()
    {
        Selected_First = true;
    }


    public virtual void Activate_Second()
    {
        Selected_Second = true;
    }

    public virtual void Activate_Last()
    {
        Selected_Last = true;
        Selected = true;
    }

    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))                    //Level 시스템이 구축 된다면 레벨업 후 변수의 변화를 받아 난수를 생성하여 결정할 예정
        {
            foreach (Skill_Manager sm in scripts)
            {
                if (sm.Skill_Num == 15)
                {
                    if (!sm.Selected_First)
                        sm.Activate_First();
                    else if (!sm.Selected_Second)
                        sm.Activate_Second();
                    else if (!sm.Selected_Last)
                        sm.Activate_Last();
                }
            }
        }
    }
}
