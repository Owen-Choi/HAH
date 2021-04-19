using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(GetItemCount("MutantSample"));
        }
    }
}
