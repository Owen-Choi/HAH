using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    int require;    int DefaultRequire = 5;
    public GameObject BackPack;
    void Start()
    {
        require = DefaultRequire + Player_Stat.instance.Level;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= require)
            {
                Player_Stat.instance.Level++;
                Player_Stat.instance.isLevelUp = true;
                BackPack.GetComponent<BackPack>().UseItem("MutantSample", require);
                require = DefaultRequire + Player_Stat.instance.Level;
            }   //# 이제 레벨업했음을 알리고 스킬 시스템에서 랜덤으로 3개의 스킬이 뜨게 해야한다. 스킬마다 스프라이트를 부여해야하고 Seleted가 true인 스킬은 뜨지 않게 해야한다.
        }
    }
}
