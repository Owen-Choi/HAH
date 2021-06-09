using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KitchenCount : MonoBehaviour
{
    public Text FoodCount;
    public Text WaterCount;
    public GameObject BackPack;

    private void Update()
    {
        FoodCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Food").ToString();
        WaterCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Water").ToString();
    }
}
