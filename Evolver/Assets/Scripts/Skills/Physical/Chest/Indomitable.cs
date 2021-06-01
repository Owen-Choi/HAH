using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indomitable : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    [SerializeField]
    bool isOnce;
    float OriginalArmor;
    private void Awake()
    {
        this.Skill_Num = 30;
        //this.Sprite_Num =
        this.Skill_Name = "Indomitable";
        this.Skill_Desc = "";
        PlayerCache = Player;
        OriginalArmor = Player_Stat.instance.armor;
    }
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                OriginalArmor = Player_Stat.instance.armor;
            else
            {
                if (!isOnce && PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))
                {
                    isOnce = true;
                    Player_Stat.instance.armor += Player_Stat.instance.armor * 0.5f;
                    StartCoroutine("Duration");

                }
            }
        }
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5f);
        isOnce = false;
        
        Player_Stat.instance.armor = OriginalArmor;                 //방어력 원상복귀.
            
    }
}
