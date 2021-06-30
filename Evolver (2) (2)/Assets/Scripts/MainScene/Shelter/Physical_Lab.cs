using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Lab : MonoBehaviour
{
    float radius;
    public Text Require;
    public Text MutantSampleCount;
    public GameObject BackPack;
    public GameObject GameManager;
    GameObject GMCache;
    private void Start()
    {
        radius = 1f;                                     
        Require.text = "1";
        GMCache = GameManager;
    }
    private void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= 1)          //�������� ǥ���� ����ϴٸ� Player_Stat�� Physical_Level�� �ø� �� �ִ�.
                {
                    Player_Stat.instance.Physical_Level++;
                    Player_Stat.instance.isPhysical_LevelUp = true;
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", 1);
                    GMCache.GetComponent<Game_Manager>().SkillOpen = true;
                    Time.timeScale = 0;
                }
            }
        }
    }
}
