using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crisis_Guide : MonoBehaviour
{
    float time;

    private void Awake()
    {
        time = 0f;
    }
    private void Update()
    {
        time += Time.deltaTime;

        if(time > 5f)
        {
            time = 0f;
            this.gameObject.SetActive(false);
        }
    }
}
