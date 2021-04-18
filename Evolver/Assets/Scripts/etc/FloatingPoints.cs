using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("delay");
    }

    // Update is called once per frame
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
