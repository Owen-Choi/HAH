using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCounter : MonoBehaviour
{
    public Text MutantSampleCount;
    public GameObject BackPack;
    void Update()
    {
        MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
    }
}
