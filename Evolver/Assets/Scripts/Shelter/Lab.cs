using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lab : MonoBehaviour
{
    public Canvas SkillChoose;
    public Text Require;
    int require;    int DefaultRequire = 5;
    public GameObject BackPack;
    void Start()
    {
        require = DefaultRequire + Player_Stat.instance.Level;
        Require.text = require.ToString();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(BackPack.GetComponent<BackPack>().GetItemCount("MutantSample") >= require)
            {
                Player_Stat.instance.Level++;
                Player_Stat.instance.isLevelUp = true;
                BackPack.GetComponent<BackPack>().UseItem("MutantSample", require);
                require = DefaultRequire + Player_Stat.instance.Level;
                SkillChoose.gameObject.SetActive(true);             //��ų ����â Ȱ��ȭ
                Require.text = require.ToString();
                //�̸� ������ ��ư ������ 3���� ��������Ʈ ��� ���ؼ� �־��ִ� �ڵ� �ۼ��ϱ�
            }   //# ���� ������������ �˸��� ��ų �ý��ۿ��� �������� 3���� ��ų�� �߰� �ؾ��Ѵ�. ��ų���� ��������Ʈ�� �ο��ؾ��ϰ� Selected�� true�� ��ų�� ���� �ʰ� �ؾ��Ѵ�.
        }
    }
}
