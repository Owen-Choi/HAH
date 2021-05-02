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
        //아이템을 얻는 건 그렇다 쳐도 사용하는 아이템은 어떻게 반영을 해주지?
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
        }
    }
}
