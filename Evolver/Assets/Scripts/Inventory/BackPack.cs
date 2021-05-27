using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackPack : MonoBehaviour
{
    //BackPack Ŭ������ �߰� ������ �Ѵ�. Ư�� Ŭ�������� �κ��丮�� �����ϸ� �ٸ� Ŭ�������� �κ��丮�� ������ �� �����Ƿ� BackPack�� ��ǥ�ڷ� ���� �� �ش� ������Ʈ�� �߰��Ͽ� �����Ѵ�.
    private Inventory inventory;
    private void Awake()
    {
        //�κ��丮 ���� ����
        inventory = new Inventory();
    }

    public void AddItem(string name, int count)
    {
        inventory.AddItem(name, count);
    }

    public void setDropPercent(string name, int percent)
    {
        inventory.SetDropPercent(name, percent);
    }

    public int GetDropPercent(string name)
    {
        return inventory.getDropPercent(name);
        
    }
    
    public int GetItemCount(string name)
    {
        return inventory.getItemCount(name);
    }

    public void UseItem(string name, int count)
    {
        inventory.UseItem(name, count);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))                         //HŰ ������ ���� ��� ���
        {
            if(GetItemCount("Bandage") != 0)
            {
                Player_Stat.instance.health += 15;
                UseItem("Bandage", 1);
            }
        }
       
    }
}
