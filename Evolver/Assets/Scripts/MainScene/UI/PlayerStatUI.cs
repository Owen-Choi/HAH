using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatUI : MonoBehaviour
{
    public Text DamageValue;
    public Text ArmorValue;
    public Text CriticalPercentValue;
    public Text CriticalDamageValue;

    // Update is called once per frame
    void Update()
    {
        DamageValue.text = Player_Stat.instance.damage.ToString();
        ArmorValue.text = Player_Stat.instance.armor.ToString();
        CriticalPercentValue.text = Player_Stat.instance.criticalPercent.ToString();
        CriticalDamageValue.text = Player_Stat.instance.criticalDamage.ToString();
    }
}
