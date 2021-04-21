using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public GameObject BackPack;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            BackPack.GetComponent<BackPack>().UseItem("Food", 1);
            Player_Stat.instance.RadioActive -= 10;
            Player_Stat.instance.healthMax += 10;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            BackPack.GetComponent<BackPack>().UseItem("Water", 1);
            Player_Stat.instance.Max_Stamina += 5;              //수치 조정하기
        }
    }
}
