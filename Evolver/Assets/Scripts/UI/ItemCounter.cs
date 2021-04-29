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
    //public GameObject BackPack;

    void Start()
    {
        // # Update �Լ� �ȿ��� Find�� ����� �ἱ �ȵȴ�. Awake�� Start���� �ѹ� Find�� ã�Ƽ� UI�� ǥ�����ְ� �� �ڷδ� ������ ���� �� ���� �ش� ������Ʈ���� ������ �ؾ��� �� ����.
        MutantSampleCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
        BandageCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("Bandage").ToString();
        MedikitCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("Medikit").ToString();
        StaminaPotionCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("StaminaPotion").ToString();
        FoodCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("Food").ToString();
        WaterCount.text = GameObject.Find("BackPack").GetComponent<BackPack>().GetItemCount("Water").ToString();
    }
}
