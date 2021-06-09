using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemCollecter : MonoBehaviour
{
    int tempCount;
    public GameObject BasicUI;
    public GameObject BackPack;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Shelter")
        {
            BasicUI.GetComponent<ItemCounterForMapping>().MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
            BasicUI.GetComponent<ItemCounterForMapping>().BandageCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Bandage").ToString();
            BasicUI.GetComponent<ItemCounterForMapping>().MedikitCount.text = BackPack.GetComponent<BackPack>().GetItemCount("Medikit").ToString();
            BasicUI.GetComponent<ItemCounterForMapping>().StaminaPotionCount.text = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Item")
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("MutantSample"))
            {
                tempCount = Random.Range(1, 4);
                BackPack.GetComponent<BackPack>().AddItem("MutantSample", tempCount);
                BasicUI.GetComponent<ItemCounterForMapping>().MutantSampleCount.text = (int.Parse(BasicUI.GetComponent<ItemCounterForMapping>().MutantSampleCount.text) + tempCount).ToString();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Medikit"))
            {
                BackPack.GetComponent<BackPack>().AddItem("Medikit", 1);
                BasicUI.GetComponent<ItemCounterForMapping>().MedikitCount.text = (int.Parse(BasicUI.GetComponent<ItemCounterForMapping>().MedikitCount.text) + 1).ToString();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Bandage"))
            {
                BackPack.GetComponent<BackPack>().AddItem("Bandage", 1);
                BasicUI.GetComponent<ItemCounterForMapping>().BandageCount.text = (int.Parse(BasicUI.GetComponent<ItemCounterForMapping>().BandageCount.text) + 1).ToString();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("StaminaPotion"))
            {
                BackPack.GetComponent<BackPack>().AddItem("StaminaPotion", 1);
                BasicUI.GetComponent<ItemCounterForMapping>().StaminaPotionCount.text = (int.Parse(BasicUI.GetComponent<ItemCounterForMapping>().StaminaPotionCount.text) + 1).ToString();
            }

            // # 음식과 물같은 경우엔 UI에 표시가 안되므로 따로 UI에 띄울 필요가 없다.
            if (other.gameObject.layer == LayerMask.NameToLayer("FoodItem"))
            {
                BackPack.GetComponent<BackPack>().AddItem("Food", 1);
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("WaterItem"))
            {
                BackPack.GetComponent<BackPack>().AddItem("Water", 1);
            }
        }
    }
}
