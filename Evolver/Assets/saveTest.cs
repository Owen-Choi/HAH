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
        SaveSystem.LoadStat();
        SaveSystem.LoadSkill();
        SaveSystem.LoadPhysicalSkill();
    }

}
