using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveTest : MonoBehaviour
{
   public void SaveProcess()
    {
        SaveSystem.SaveStat();
        SaveSystem.SaveSkill();
        SaveSystem.SavePhysicalSkill();
    }

    public void LoadProcess()
    {
        SaveSystem.LoadPhysicalSkill();
        SaveSystem.LoadSkill();
        SaveSystem.LoadStat();


        LoadSystem.LoadPhysicalSkill();
        LoadSystem.LoadSkill();
        LoadSystem.LoadStat(); 
    }

}
