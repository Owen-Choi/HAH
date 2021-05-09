using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Physical_Part_Choose : MonoBehaviour
{
    public GameObject Physic_ChooseUI;
    bool ForOne;
    int randNum1;   int randNum2;
   // # ��ü���� ��ư 2�� ���� ����
    void Start()
    {
        Physic_ChooseUI.gameObject.SetActive(false);        // �ϴ��� ������Ʈ ���α�
        
    }

    // # 1 : �ٸ� 2 : �� 3 : ���� 4 : �Ӹ� 
    void Update()
    {
        if (Player_Stat.instance.isPhysical_LevelUp && !ForOne)
        {
            randNum1 = Random.Range(1, 5);
            do
                randNum2 = Random.Range(1, 5);
            while (randNum1 == randNum2);               //�ΰ��� ���� ���� �� ����.
            if(randNum1 == 1)
            {
                 
            }
            // # �ΰ��� ������ ���ؼ� ��������Ʈ �̹����� ������ �Ѱ��־�� �Ѵ�.
            Physic_ChooseUI.gameObject.SetActive(true);
        }   
    }

    IEnumerator Physical_LevelUp_Delay()
    {
        yield return new WaitForEndOfFrame();
        Player_Stat.instance.isPhysical_LevelUp = false;
        ForOne = false;
    }
}
