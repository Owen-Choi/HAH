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

    // # 이 스크립트에서 사용하는 아이템의 개수를 UI에 반영해줄 방법을 생각해보자.
    void Update()
    {
        //MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        //BandageCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        //MedikitCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        //StaminaPotionCount.text = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        //RadioActive.text = Player_Stat.instance.RadioActive.ToString();
        //Thirsty.text = (Player_Stat.instance.DefaultStaminaMax - Player_Stat.instance.Max_Stamina).ToString();
    }
}
