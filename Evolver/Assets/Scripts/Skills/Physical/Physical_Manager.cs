using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physical_Manager : MonoBehaviour
{
    public int Skill_Num;
    public int Sprite_Num;
    public Physical_Manager[] scripts;
    public bool Selected;
    void Start()
    {
        scripts = this.GetComponents<Physical_Manager>();
        this.Selected = false;
    }

}
