using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCounterForMapping : MonoBehaviour
{
    public Text MutantSampleCount;
    public Text BandageCount;
    public Text MedikitCount;
    public Text StaminaPotionCount;
    public Text RadioActive;
    public Text Thirsty;
    public Text Starvation;
    public GameObject BackPack;

    void Update()
    {
        MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        BandageCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        MedikitCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        StaminaPotionCount.text = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        RadioActive.text = Player_Stat.instance.RadioActive.ToString();
        Thirsty.text = (Player_Stat.instance.thirsty).ToString();
        Starvation.text = (Player_Stat.instance.Starvation).ToString();
    }
}
