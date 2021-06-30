using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    float radius = 1;
    public GameObject BackPack;
    GameObject BackPackCache;
    public int StarvationDecrease;
    public int ThirstyDecrease;

    private void Awake()
    {
        StarvationDecrease = 10;
        ThirstyDecrease = 5;
        BackPackCache = BackPack;
    }
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E) && BackPackCache.GetComponent<BackPack>().GetItemCount("Food") > 0)
            {
                BackPackCache.GetComponent<BackPack>().UseItem("Food", 1);
                if (Player_Stat.instance.Starvation > StarvationDecrease)
                    Player_Stat.instance.Starvation -= StarvationDecrease;
                else
                    Player_Stat.instance.Starvation = 0;
                //Player_Stat.instance.healthMax += RadioActiveDecrease;    healthMax값은 Player_Stat에서 자동으로 업데이트 된다.
            }

            if (Input.GetKeyDown(KeyCode.R) && BackPackCache.GetComponent<BackPack>().GetItemCount("Water") > 0)
            {
                BackPackCache.GetComponent<BackPack>().UseItem("Water", 1);
                if (Player_Stat.instance.thirsty > ThirstyDecrease)
                    Player_Stat.instance.thirsty -= ThirstyDecrease;              //수치 조정하기
                else
                    Player_Stat.instance.thirsty = 0f;
            }
        }
        
    }
}
