using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCounter : MonoBehaviour
{
    public Text MutantSampleCount;
    public Text BandageCount;
    public Text MedikitCount;
    public Text StaminaPotionCount;
    public GameObject BackPack;
    void Update()
    {
        MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        BandageCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        MedikitCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        StaminaPotionCount.text = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
    }
}
