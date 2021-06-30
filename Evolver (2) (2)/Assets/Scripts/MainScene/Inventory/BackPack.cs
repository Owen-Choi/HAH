using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackPack : MonoBehaviour
{
    //BackPack 클래스는 중계 역할을 한다. 특정 클래스에서 인벤토리를 생성하면 다른 클래스에서 인벤토리를 참조할 수 없으므로 BackPack이 대표자로 참조 후 해당 오브젝트를 추가하여 참조한다.
    private Inventory inventory;
    private void Awake()
    {
        //인벤토리 최초 생성
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
        if(Input.GetKeyDown(KeyCode.Alpha1))                         //1번 누르면 밴드 사용
        {
            if(GetItemCount("Bandage") > 0)
            {
                Player_Stat.instance.health += 15;
                UseItem("Bandage", 1);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))                        //2번 누르면 메디킷 사용
        {
            if(GetItemCount("Medikit") > 0)
            {
                Player_Stat.instance.health += 80;
                UseItem("Medikit", 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))                       //3번을 누르면 스테미나 회복약 사용
        {
            if (GetItemCount("StaminaPotion") > 0)
            {
                Player_Stat.instance.stamina = Player_Stat.instance.DefaultStaminaMax;
                UseItem("StaminaPotion", 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))                       //4번을 누르면 방사능 회복
        {
            if(GetItemCount("Pill") > 0)
            {
                Player_Stat.instance.RadioActive -= 10;
                UseItem("Pill", 1);
            }
        }
    }
}
