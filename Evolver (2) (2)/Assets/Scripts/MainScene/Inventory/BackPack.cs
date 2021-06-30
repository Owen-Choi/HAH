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

    public void SetItemCount(string name, int count)
    {
        inventory.SetItemCount(name, count);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))                         //1�� ������ ��� ���
        {
            if(GetItemCount("Bandage") > 0)
            {
                Player_Stat.instance.health += 15;
                UseItem("Bandage", 1);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))                        //2�� ������ �޵�Ŷ ���
        {
            if(GetItemCount("Medikit") > 0)
            {
                Player_Stat.instance.health += 80;
                UseItem("Medikit", 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))                       //3���� ������ ���׹̳� ȸ���� ���
        {
            if (GetItemCount("StaminaPotion") > 0)
            {
                Player_Stat.instance.stamina = Player_Stat.instance.DefaultStaminaMax;
                UseItem("StaminaPotion", 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))                       //4���� ������ ���� ȸ��
        {
            if(GetItemCount("Pill") > 0)
            {
                Player_Stat.instance.RadioActive -= 10;
                UseItem("Pill", 1);
            }
        }
    }
}
