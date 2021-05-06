using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lab : MonoBehaviour
{
    float radius;
    public Text Require;
    int require;    int DefaultRequire = 5;
    public Text MutantSampleCount;
    public GameObject BackPack;
    void Start()
    {
        require = DefaultRequire;                   //�� ��ȯ �ý��� ���� ���� �ڵ� : ���翡�� ���� ����.                  
        Require.text = require.ToString();
        radius = 1;
    }

   
    void Update()
    {
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));
        if (circle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= require)
                {
                    Player_Stat.instance.Level++;
                    Player_Stat.instance.isLevelUp = true;
                    BackPack.GetComponent<BackPack>().UseItem("MutantSample", require);
                    MutantSampleCount.text = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample").ToString();
                    require = DefaultRequire + 1;
                    // #������ �ڵ忡���� Lab ������Ʈ���� SkillChoose UI�� �������, ����� SkillChoose ��ũ��Ʈ���� �����ϴ� ������ �����Ͽ���.
                    //Require.text = require.ToString();
                    Require.text = require.ToString();
                    //�̸� ������ ��ư ������ 3���� ��������Ʈ ��� ���ؼ� �־��ִ� �ڵ� �ۼ��ϱ�
                }   //# ���� ������������ �˸��� ��ų �ý��ۿ��� �������� 3���� ��ų�� �߰� �ؾ��Ѵ�. ��ų���� ��������Ʈ�� �ο��ؾ��ϰ� Selected�� true�� ��ų�� ���� �ʰ� �ؾ��Ѵ�.
            }
        }
    }
}
