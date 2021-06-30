using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Carrier : MonoBehaviour
{
    public GameObject Player;   GameObject PlayerCache;

    public float buff_DMG;
    public float buff_Armor;
    public float buff_MS;
    public float buff_CP;

    private void Awake()
    {
        buff_DMG = Player_Stat.instance.damage;
        buff_Armor = Player_Stat.instance.armor;
        buff_CP = Player_Stat.instance.criticalPercent;
        buff_MS = Player_Stat.instance.moveSpeed;

        PlayerCache = Player;
    }

    private void Update()
    {
        if (PlayerCache.layer != LayerMask.NameToLayer("PlayerInShelter"))           //�÷��̾ ���Ϳ� �ִ� ��Ȳ�� �ƴ϶��
        {
            Player_Stat.instance.damage = buff_DMG;
            Player_Stat.instance.armor = buff_Armor;
            Player_Stat.instance.criticalPercent = buff_CP;
            Player_Stat.instance.moveSpeed = buff_MS;
        }
        else                                                                        //�ɷ�ġ�� ������ ���� �� �ִ� ���Ϳ����� ������ ���� ��� ������Ʈ ���ش�.
        {
            buff_DMG = Player_Stat.instance.damage;
            buff_Armor = Player_Stat.instance.armor;
            buff_CP = Player_Stat.instance.criticalPercent;
            buff_MS = Player_Stat.instance.moveSpeed;
        }
    }
}
