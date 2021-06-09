using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Arrow_Weapon : MonoBehaviour
{
    Vector3 shootDirection;
    int behind = 5;
    int front = 7;
    public float offset = 0.0f;
    SpriteRenderer sp;
    public float increaseDamage = 0f; int MaxHoldingDamage;
    float launchForce; public float increaseLaunchForce = 0f; int MaxHoldingLaunchForce;
    public float HoldingTime; public float EverySecond;
    public bool ischanged; bool Zero_Stamina;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        launchForce = Player_Stat.instance.launchForce - 1;
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Player.isHideWeapon)
            sp.sortingOrder = behind;
        else
            sp.sortingOrder = front;

    }
}
