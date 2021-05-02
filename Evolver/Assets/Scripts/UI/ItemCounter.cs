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
    public Text FoodCount;
    public Text WaterCount;
    public GameObject BackPack;
    //public GameObject BackPack;
    
    void Update()
    {
        // # Update 함수 안에서 Find는 절대로 써선 안된다. Awake나 Start에서 한번 Find로 찾아서 UI에 표시해주고 그 뒤로는 변동이 생길 때 마다 해당 오브젝트에서 변경을 해야할 것 같다.
        MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        BandageCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        MedikitCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        StaminaPotionCount.text = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        FoodCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Food").ToString();
        WaterCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Water").ToString();
    }
}
