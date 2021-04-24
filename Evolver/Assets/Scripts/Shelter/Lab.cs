using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    int require;    int DefaultRequire = 5;
    public GameObject BackPack;
    void Start()
    {
        require = DefaultRequire + Player_Stat.instance.Level;
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
            }   //# ���� ������������ �˸��� ��ų �ý��ۿ��� �������� 3���� ��ų�� �߰� �ؾ��Ѵ�. ��ų���� ��������Ʈ�� �ο��ؾ��ϰ� Seleted�� true�� ��ų�� ���� �ʰ� �ؾ��Ѵ�.
        }
    }
}
