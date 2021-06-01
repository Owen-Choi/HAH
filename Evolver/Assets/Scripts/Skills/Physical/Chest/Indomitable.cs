using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indomitable : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    [SerializeField]
    bool isOnce;
    float OriginalArmor;    float DefaultArmor;
    private void Awake()
    {
        this.Skill_Num = 30;
        //this.Sprite_Num =
        this.Skill_Name = "Indomitable";
        this.Skill_Desc = "";
        PlayerCache = Player;
        OriginalArmor = DefaultArmor = Player_Stat.instance.armor;
    }
    void Update()
    {
        if (this.Selected)
        {
            if(!isOnce && PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))
            {
                isOnce = true;
                OriginalArmor = Player_Stat.instance.armor;
                Player_Stat.instance.armor += Player_Stat.instance.armor * 0.5f;
                StartCoroutine("Duration");
                
            }

            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                DefaultArmor = OriginalArmor = Player_Stat.instance.armor;
        }
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5f);
        isOnce = false;
        if (DefaultArmor != OriginalArmor)
            Player_Stat.instance.armor = OriginalArmor;                 //방어력 원상복귀.
        else
            Player_Stat.instance.armor = DefaultArmor;
    }
}
