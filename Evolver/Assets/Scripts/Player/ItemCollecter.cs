using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemCollecter : MonoBehaviour
{
    int tempCount;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Shelter")
        {
            GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().MutantSampleCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
            GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().BandageCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("Bandage").ToString();
            GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().MedikitCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("Medikit").ToString();
            GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().StaminaPotionCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
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
                GameObject.Find("BackPack").GetComponent<BackPack>().AddItem("MutantSample", tempCount);
                GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().MutantSampleCount.text = (int.Parse(GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().MutantSampleCount.text) + tempCount).ToString();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Medikit"))
            {
                GameObject.Find("BackPack").GetComponent<BackPack>().AddItem("Medikit", 1);
                GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().MedikitCount.text = (int.Parse(GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().MedikitCount.text) + 1).ToString();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Bandage"))
            {
                GameObject.Find("BackPack").GetComponent<BackPack>().AddItem("Bandage", 1);
                GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().BandageCount.text = (int.Parse(GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().BandageCount.text) + 1).ToString();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("StaminaPotion"))
            {
                GameObject.Find("BackPack").GetComponent<BackPack>().AddItem("StaminaPotion", 1);
                GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().StaminaPotionCount.text = (int.Parse(GameObject.Find("BasicUI").GetComponent<ItemCounterForMapping>().StaminaPotionCount.text) + 1).ToString();
            }
        }
    }
}
