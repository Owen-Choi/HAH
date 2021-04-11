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
                time += Time.deltaTime;         //가능하면 델타타임은 프레임 오차때문에 안쓸려고 했는데 코루틴을 쓸 자신이 없다.
                if (time >= MaxStack)
                {
                    FullCharge = true;
                    time = 0f;
                }
            }
        }
        if (FullCharge)     //AbsolCrit가 false가 돼도 여기서 바로 true로 바껴서 오류가 뜬다.
        {
            FullCharge = false;
            Player_Stat.instance.AbsolCrit = true;
        }
    }

  
}
