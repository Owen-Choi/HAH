using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    float radius = 1;
    public GameObject BackPack;
    public int RadioActiveDecrease;


    private void Awake()
    {
        RadioActiveDecrease = 10;
    }
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BackPack.GetComponent<BackPack>().UseItem("Food", 1);
                Player_Stat.instance.RadioActive -= RadioActiveDecrease;
                Player_Stat.instance.healthMax += RadioActiveDecrease;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                BackPack.GetComponent<BackPack>().UseItem("Water", 1);
                Player_Stat.instance.Max_Stamina += 5;              //수치 조정하기
            }
        }
        
    }
}
