using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(GetItemCount("MutantSample"));
        }
    }
}
