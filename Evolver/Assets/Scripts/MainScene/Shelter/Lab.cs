using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lab : MonoBehaviour
{
    float radius;
    public Text Require;
    public Text MutantSampleCount;
    public GameObject BackPack;

    public GameObject GameManager;
    GameObject GMCache;
    void Start()
    {                 
        Require.text = "1";
        radius = 1;
        GMCache = GameManager;
    }

   
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= 1)
                {
                    Player_Stat.instance.Level++;
                    Player_Stat.instance.isLevelUp = true;
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", 1);
                    GMCache.GetComponent<Game_Manager>().SkillOpen = true;
                    Time.timeScale = 0;
                    //�̸� ������ ��ư ������ 3���� ��������Ʈ ��� ���ؼ� �־��ִ� �ڵ� �ۼ��ϱ�
                }   //# ���� ������������ �˸��� ��ų �ý��ۿ��� �������� 3���� ��ų�� �߰� �ؾ��Ѵ�. ��ų���� ��������Ʈ�� �ο��ؾ��ϰ� Selected�� true�� ��ų�� ���� �ʰ� �ؾ��Ѵ�.
            }
        }
    }
}
