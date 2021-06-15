using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Limitation_Guide : MonoBehaviour
{
    float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 5f)
        {
            time = 0f;
            this.gameObject.SetActive(false);
        }
    }
}
