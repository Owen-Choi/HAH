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

   
}
