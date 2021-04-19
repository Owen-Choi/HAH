using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public GameObject BackPack;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Item")
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("MutantSample"))
                BackPack.GetComponent<BackPack>().AddItem("MutantSample", Random.Range(1, 4));
        }
    }
}
