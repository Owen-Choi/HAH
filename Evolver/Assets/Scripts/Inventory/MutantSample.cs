using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSample : MonoBehaviour
{
    public Inventory inventory;
    public Item item;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //����� �÷��� �߰� ����
        }
    }

    private void OnDestroy()
    {
        inventory.AddItem(new Item { itemtype = Item.ItemType.MutantSample, amount = 1 });          //���� : �κ��丮 �⺻ �����ڸ� �ҷ����� ���� ������ ����. ��ġ�ϱ�
    }
}
