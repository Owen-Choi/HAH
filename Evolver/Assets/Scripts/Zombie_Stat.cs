using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Stat : MonoBehaviour
{
    public float Health;
    public float Power = 10f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent || Player_Stat.instance.AbsolCrit)
            {
                if (Player_Stat.instance.AbsolCrit)
                {
                    Player_Stat.instance.AbsolCrit = false;
                }
                Health -= ((Player_Stat.instance.damage + other.GetComponent<Arrow>().HoldDamage) * (float)(Player_Stat.instance.criticalDamage / 100));
                CameraShake.instance.cameraShake();
            }
            else
                Health -= (Player_Stat.instance.damage + other.GetComponent<Arrow>().HoldDamage);
        }
    }
    private void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}
