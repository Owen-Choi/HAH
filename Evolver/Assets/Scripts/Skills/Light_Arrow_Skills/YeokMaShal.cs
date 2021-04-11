using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeokMaShal : Skill_Manager
{
    public GameObject Player;
    public bool isMoving;  int MaxStack = 15;  public float time; bool FullCharge;  bool hDown; bool hUp;   bool vDown; bool vUp; bool hIng; bool vIng;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 5;
    }

    // Update is called once per frame
    void Update()
    {
        hDown = Input.GetButtonDown("Horizontal");
        hUp = Input.GetButtonUp("Horizontal");
        vDown = Input.GetButtonDown("Vertical");
        vUp = Input.GetButtonUp("Vertical");
        hIng = Input.GetButton("Horizontal");
        vIng = Input.GetButton("Vertical");

        if (this.Selected_First)
        {
            this.Selected = true;
            if (hDown || vDown)
                isMoving = true;

            if ((hUp && !vIng) || (vUp && !hIng))
                isMoving = false;

            if (isMoving && !FullCharge)
            {
                time += Time.deltaTime;         //�����ϸ� ��ŸŸ���� ������ ���������� �Ⱦ����� �ߴµ� �ڷ�ƾ�� �� �ڽ��� ����.
                if (time >= MaxStack)
                {
                    FullCharge = true;
                    time = 0f;
                }
            }
        }
        if (FullCharge)     //AbsolCrit�� false�� �ŵ� ���⼭ �ٷ� true�� �ٲ��� ������ ���.
        {
            FullCharge = false;
            Player_Stat.instance.AbsolCrit = true;
        }
    }

  
}
