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
    public GameObject GameManager;
    GameObject GMCache;
    private void Start()
    {
        radius = 1f;
        require = DefaultRequire;                                     
        Require.text = require.ToString();
        GMCache = GameManager;
    }
    private void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= require)          //돌연변이 표본이 충분하다면 Player_Stat의 Physical_Level을 올릴 수 있다.
                {
                    Player_Stat.instance.Physical_Level++;
                    Player_Stat.instance.isPhysical_LevelUp = true;
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", require);
                    require++;
                    Require.text = require.ToString();
                    GMCache.GetComponent<Game_Manager>().SkillOpen = true;
                    Time.timeScale = 0;
                }
            }
        }
    }
}
