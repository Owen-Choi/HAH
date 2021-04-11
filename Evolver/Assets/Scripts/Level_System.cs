using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_System : MonoBehaviour
{
    public int Player_level = 1;
    public bool is_LevelUp;
    public static Level_System instance;
    public bool IsPauseTime;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPauseTime)
            IsPauseTime = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LevelUpItem")
        {
            Time.timeScale = 0.00001f;
            IsPauseTime = true;
            is_LevelUp = true;
        }
    }
}
