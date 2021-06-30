using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCounterForMapping : MonoBehaviour
{
    public Text MutantSampleCount;  Text MutantSampleCountCache;
    public Text BandageCount;       Text BandageCountCache;
    public Text MedikitCount;       Text MedikitCountCache;
    public Text StaminaPotionCount; Text StaminaPotionCountCache;
    public Text RadioActive;        Text RadioActiveCache;
    public Text Thirsty;            Text ThirstyCache;
    public Text Starvation;         Text StarvationCache;
    public Text PillCount;          Text PillCountCache;
    public GameObject BackPack;     GameObject BackPackCache;


    private void Awake()
    {
        BackPackCache = BackPack;
        MutantSampleCountCache = MutantSampleCount;
        BandageCountCache = BandageCount;
        MedikitCountCache = MedikitCount;
        StaminaPotionCountCache = StaminaPotionCount;
        PillCountCache = PillCount;
        RadioActiveCache = RadioActive;
        ThirstyCache = Thirsty;
        StarvationCache = Starvation;
    }
    void Update()
    {
        MutantSampleCountCache.text = BackPackCache.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        BandageCountCache.text = BackPackCache.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        MedikitCountCache.text = BackPackCache.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        StaminaPotionCountCache.text = BackPackCache.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        PillCountCache.text = BackPackCache.GetComponent<BackPack>().GetItemCount("Pill").ToString();
        RadioActiveCache.text = Player_Stat.instance.RadioActive.ToString();
        ThirstyCache.text = (Player_Stat.instance.thirsty).ToString();
        StarvationCache.text = (Player_Stat.instance.Starvation).ToString();
    }
}
