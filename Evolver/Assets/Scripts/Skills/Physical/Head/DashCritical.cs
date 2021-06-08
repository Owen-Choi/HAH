using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCritical : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isDash;    bool One;
    public GameObject BuffCarrier;
    GameObject BCcache;
    private void Awake()
    {
        this.Skill_Num = 37;
        this.Sprite_Num = 9;
        this.Skill_Name = "������ �µ�";
        this.Skill_Desc = "���ְ� ���� �� 5�� ���� ġ��Ÿ �߻� Ȯ���� 30% �����Ѵ�.";
        BCcache = BuffCarrier;
    }
    void Start()
    {
        PlayerCache = Player;
        One = false;
    }
    void Update()
    {
        if (this.Selected)
        {
                if (!One && PlayerCache.GetComponent<Player>().isDash)
                {
                    One = true;
                    //Player_Stat.instance.criticalPercent += 30f;
                    BCcache.GetComponent<Buff_Carrier>().buff_CP += 30f;
                    StartCoroutine("CriticalDuration");
                }
        }
    }

    IEnumerator CriticalDuration()
    {
        yield return new WaitForSeconds(5f);
        //Player_Stat.instance.criticalPercent = Original_CritPercent;
        BCcache.GetComponent<Buff_Carrier>().buff_CP -= 30f;
        One = false;
        
    }
}
