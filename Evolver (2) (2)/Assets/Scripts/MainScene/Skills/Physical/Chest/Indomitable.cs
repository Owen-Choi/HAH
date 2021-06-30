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
    public GameObject BuffCarrier;
    GameObject BCcache;
    
    private void Awake()
    {
        this.Skill_Num = 30;
        this.Sprite_Num = 11;
        this.Skill_Name = "�ұ�";
        this.Skill_Desc = "������ ���ظ� ���� ���� 5�� ���� ������ 1.5�谡 �ȴ�.";
        PlayerCache = Player;
        OriginalArmor = Player_Stat.instance.armor;
        BCcache = BuffCarrier;
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
                    //player_Stat.instance.armor += Player_Stat.instance.armor * 0.5f;
                    BCcache.GetComponent<Buff_Carrier>().buff_Armor += OriginalArmor * 0.5f;
                    StartCoroutine("Duration");

                }
            }
        }
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5f);
        isOnce = false;

        //Player_Stat.instance.armor = OriginalArmor;                 //���� ���󺹱�.
        BCcache.GetComponent<Buff_Carrier>().buff_Armor -= OriginalArmor * 0.5f;
            
    }
}
