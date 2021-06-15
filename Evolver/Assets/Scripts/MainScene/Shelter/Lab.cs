using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lab : MonoBehaviour
{
    float radius;
    public Text Require;
    public Text MutantSampleCount;
    public GameObject BackPack;
    public Text Current_Skills;
    public GameObject GameManager;
    GameObject GMCache;
    public GameObject Limit_Guide;
    void Start()
    {                 
        Require.text = "1";
        radius = 1;
        GMCache = GameManager;
    }

   
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Player_Stat.instance.SkillLimit < 10 && BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= 1)
                {
                    Player_Stat.instance.Level++;
                    Player_Stat.instance.isLevelUp = true;
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", 1);
                    GMCache.GetComponent<Game_Manager>().SkillOpen = true;
                    Time.timeScale = 0;
                    //미리 만들어둔 버튼 프레임 3개에 스프라이트 경로 통해서 넣어주는 코드 작성하기
                }   //# 이제 레벨업했음을 알리고 스킬 시스템에서 랜덤으로 3개의 스킬이 뜨게 해야한다. 스킬마다 스프라이트를 부여해야하고 Selected가 true인 스킬은 뜨지 않게 해야한다.
                else if(Player_Stat.instance.SkillLimit >= 10)
                {
                    Limit_Guide.gameObject.SetActive(true);
                }
            }
        }
    }
}
