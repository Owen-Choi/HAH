using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robin_hood : Skill_Manager
{
    bool Once;  bool Twice; bool Third;
    public GameObject Player;                   //캐싱하여 사용하자
    GameObject PlayerCache;
    public GameObject ShotPoint;
    GameObject SP;
    int Count;
    void Start()
    {
        Once = Twice = Third = false;
        this.Skill_Num = 7;
        //this.Sprite_Num =
        this.Skill_Name = "Robin Hood";
        this.Skill_Desc = "+ : You can launch arrow immediately one time with high speed and power as twice damage of player while dash " +
            " ++ : You can launch arrow two times with same condition  " + " +++ : You can launch arrow three times with same condition ";
        PlayerCache = Player;                    
        SP = ShotPoint;
        Count = 0;
    }

    void Update()
    {
        if (this.Selected_First && !Once)
            Once = true;

        if (this.Selected_Second && !Twice)
            Twice = true;

        if (this.Selected_Last && !Third)
            Third = true;

        if(Once && !Twice)
        {
            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Dash") && Count < 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SP.GetComponent<ShotPoint>().RobinHood();
                    Count++;
                    StartCoroutine("SetToZero");
                }
            }
        }
        else if(Once && Twice && !Third)
        {
            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Dash") && Count < 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SP.GetComponent<ShotPoint>().RobinHood();
                    Count++;
                    StartCoroutine("SetToZero");
                }
            }
        }
        else if(Once && Twice && Third)
        {
            if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Dash") && Count < 3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SP.GetComponent<ShotPoint>().RobinHood();
                    Count++;
                    StartCoroutine("SetToZero");
                }
            }
        }
    }

    IEnumerator SetToZero()
    {
        yield return new WaitForSeconds(2f);
        Count = 0;
    }
}
