using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lab : MonoBehaviour
{
    public Text Require;
    int require;    int DefaultRequire = 5;
    public Text MutantSampleCount;
    public GameObject BackPack;
    void Start()
    {
        require = DefaultRequire + Player_Stat.instance.Level;                  //이 코드는 문제가 없다. 문제는 Player_Stat이 씬 전환 간 연동이 안될 뿐
        Require.text = require.ToString();
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
                MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
                require = DefaultRequire + Player_Stat.instance.Level;
                // #기존의 코드에서는 Lab 오브젝트에서 SkillChoose UI를 띄웠지만, 현재는 SkillChoose 스크립트에서 조정하는 것으로 변경하였다.
                //Require.text = require.ToString();
                Require.text = require.ToString();
                //미리 만들어둔 버튼 프레임 3개에 스프라이트 경로 통해서 넣어주는 코드 작성하기
            }   //# 이제 레벨업했음을 알리고 스킬 시스템에서 랜덤으로 3개의 스킬이 뜨게 해야한다. 스킬마다 스프라이트를 부여해야하고 Selected가 true인 스킬은 뜨지 않게 해야한다.
        }
    }
}
