using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lab : MonoBehaviour
{
    public Canvas SkillChoose;
    public Text Require;
    int require;    int DefaultRequire = 5;
    public GameObject BackPack;
    void Start()
    {
        require = DefaultRequire + Player_Stat.instance.Level;
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
                require = DefaultRequire + Player_Stat.instance.Level;
                SkillChoose.gameObject.SetActive(true);             //스킬 선택창 활성화
                Require.text = require.ToString();
                //미리 만들어둔 버튼 프레임 3개에 스프라이트 경로 통해서 넣어주는 코드 작성하기
            }   //# 이제 레벨업했음을 알리고 스킬 시스템에서 랜덤으로 3개의 스킬이 뜨게 해야한다. 스킬마다 스프라이트를 부여해야하고 Selected가 true인 스킬은 뜨지 않게 해야한다.
        }
    }
}
