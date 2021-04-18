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
        BackPack.instance.addItem("MuntantSample", Random.Range(1, 3));
    }
}
