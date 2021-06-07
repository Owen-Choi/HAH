using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCritical : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isDash;    bool One;
    float Original_CritPercent;

    private void Awake()
    {
        this.Skill_Num = 37;
        this.Sprite_Num = 9;
        this.Skill_Name = "예민한 태도";
        this.Skill_Desc = "질주가 끝난 후 5초 동안 치명타 발생 확률이 30% 증가한다.";
        Original_CritPercent = Player_Stat.instance.criticalPercent;
    }
    void Start()
    {
        PlayerCache = Player;
        Original_CritPercent = Player_Stat.instance.criticalPercent;
        One = false;
    }
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                Original_CritPercent = Player_Stat.instance.criticalPercent;
            else
            {
                if (!One && PlayerCache.GetComponent<Player>().isDash)
                {
                    One = true;
                    Player_Stat.instance.criticalPercent += 30f;
                    StartCoroutine("CriticalDuration");
                }
            }
        }
    }

    IEnumerator CriticalDuration()
    {
        yield return new WaitForSeconds(5f);
        Player_Stat.instance.criticalPercent = Original_CritPercent;
        One = false;
        
    }
}
