using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCritical : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isDash;    bool One;
    float Original_CritPercent; float Default_CriticalPercent;

    private void Awake()
    {
        this.Skill_Num = 37;
        this.Sprite_Num = 9;
        this.Skill_Name = "Sharp posture";
        this.Skill_Desc = "Critical attack's probability will be temporarily increased after dash";
        Default_CriticalPercent = Original_CritPercent = Player_Stat.instance.criticalPercent;
    }
    void Start()
    {
        PlayerCache = Player;
        Original_CritPercent = Default_CriticalPercent = Player_Stat.instance.criticalPercent;
        One = false;
    }
    void Update()
    {
        if (this.Selected)
        {
            if (!One && PlayerCache.GetComponent<Player>().isDash)
            {
                One = true;
                Original_CritPercent = Player_Stat.instance.criticalPercent;
                Player_Stat.instance.criticalPercent += 30f;
                StartCoroutine("CriticalDuration");
            }

            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                Default_CriticalPercent = Original_CritPercent = Player_Stat.instance.criticalPercent;

        }
    }

    IEnumerator CriticalDuration()
    {
        yield return new WaitForSeconds(5f);
        if (Default_CriticalPercent != Original_CritPercent)
            Player_Stat.instance.criticalPercent = Original_CritPercent;
        else
            Player_Stat.instance.criticalPercent = Default_CriticalPercent;
        One = false;
        
    }
}
