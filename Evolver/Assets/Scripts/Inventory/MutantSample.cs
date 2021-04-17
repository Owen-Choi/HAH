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
            //오디오 플레이 추가 예정
        }
    }

    private void OnDestroy()
    {
        inventory.AddItem(new Item { itemtype = Item.ItemType.MutantSample, amount = 1 });          //문제 : 인벤토리 기본 생성자를 불러오면 로직 에러가 생김. 조치하기
    }
}
