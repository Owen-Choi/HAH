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
    public GameObject BackPack;
    
    void Update()
    {
        MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        BandageCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        MedikitCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        StaminaPotionCount.text = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        RadioActive.text = Player_Stat.instance.RadioActive.ToString();
        Thirsty.text = (Player_Stat.instance.DefaultStaminaMax - Player_Stat.instance.Max_Stamina).ToString();              //목마름의 경우 별도의 수치를 띄우는 게 아니라 차이를 띄운다. 주의하기.
    }
}
