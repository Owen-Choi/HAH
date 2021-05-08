using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Lab : MonoBehaviour
{
    float radius;
    public Text Require;
    int require; int DefaultRequire = 3;
    public Text MutantSampleCount;
    public GameObject BackPack;
    private void Start()
    {
        radius = 1f;
        require = DefaultRequire;                                     
        Require.text = require.ToString();
    }
    private void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= require)
                {
                    Player_Stat.instance.Physical_Level++;          //아직 신체레벨업을 할 시 어떤 benefit을 주어야 할 지 정하지 못하였다. 
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", require);
                    require++;
                    Require.text = require.ToString();
                }
            }
        }
    }
}
