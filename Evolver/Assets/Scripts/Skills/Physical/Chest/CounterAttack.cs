using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : Physical_Manager
{
    bool Damaged;
    float tempDMG;
    public GameObject Player;
    private void Update()
    {
        if (this.Selected)
        {
            if(Player.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))
            {
                Damaged = true;
                tempDMG = Player_Stat.instance.damage;
                Player_Stat.instance.damage *= 1.4f;   
            }
            else if(Player.gameObject.layer == LayerMask.NameToLayer("Player") && Damaged)
            {
                Damaged = false;
                Player_Stat.instance.damage = tempDMG;
            }
        }
    }
}
