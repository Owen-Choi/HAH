using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackPack : MonoBehaviour
{
    //BackPack 클래스는 중계 역할을 한다. 특정 클래스에서 인벤토리를 생성하면 다른 클래스에서 인벤토리를 참조할 수 없으므로 BackPack이 대표자로 참조 후 해당 오브젝트를 추가하여 참조한다.
    private Inventory inventory;
    bool OnlyOnce = true;
    private void Awake()
    {
        //인벤토리 최초 생성
        inventory = new Inventory();
        // # 소용없다. 오브젝트의 변수 정보가 유지되지 않고 새로 업데이트 되는 듯
        if (SceneManager.GetActiveScene().name == "Shelter")
        {
            var obj = FindObjectsOfType<BackPack>();
            if (obj.Length == 1)
                DontDestroyOnLoad(this);
            else
                Destroy(this.gameObject);
        }
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
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(GetItemCount("Bandage") != 0)
            {
                Player_Stat.instance.health += 15;
                UseItem("Bandage", 1);
            }
        }
    }
}
