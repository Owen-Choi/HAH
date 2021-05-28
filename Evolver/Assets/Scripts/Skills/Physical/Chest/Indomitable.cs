using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indomitable : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isOnce;
    float OriginalArmor;
    private void Awake()
    {
        this.Skill_Num = 30;
        //this.Sprite_Num =
        this.Skill_Name = "Indomitable";
        this.Skill_Desc = "";
        PlayerCache = Player;
        
    }
    void Update()
    {
        if (this.Selected)
        {
            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged") && !isOnce)
            {
                isOnce = true;
                OriginalArmor = Player_Stat.instance.armor;
                Player_Stat.instance.armor += Player_Stat.instance.armor * 0.5f;

            }
        }
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5);
        isOnce = false;
        Player_Stat.instance.armor = OriginalArmor;                 //방어력 원상복귀. 오류가 발생했는지 원상복귀가 안된다. 조치하기.
    }
}
