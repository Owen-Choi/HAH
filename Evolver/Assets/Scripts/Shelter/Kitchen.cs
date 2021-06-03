using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    float radius = 1;
    public GameObject BackPack;
    public int RadioActiveDecrease;
    public int ThirstyDecrease;

    private void Awake()
    {
        RadioActiveDecrease = 10;
        ThirstyDecrease = 5;
    }
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BackPack.GetComponent<BackPack>().UseItem("Food", 1);
                if (Player_Stat.instance.RadioActive > 10)
                    Player_Stat.instance.RadioActive -= RadioActiveDecrease;
                else
                    Player_Stat.instance.RadioActive = 0f;
                //Player_Stat.instance.healthMax += RadioActiveDecrease;    healthMax���� Player_Stat���� �ڵ����� ������Ʈ �ȴ�.
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                BackPack.GetComponent<BackPack>().UseItem("Water", 1);
                if (Player_Stat.instance.thirsty > 5)
                    Player_Stat.instance.thirsty -= ThirstyDecrease;              //��ġ �����ϱ�
                else
                    Player_Stat.instance.thirsty = 0f;
            }
        }
        
    }
}
