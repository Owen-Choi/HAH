using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver_Arrow : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("Hi");
        StartCoroutine("DeleteTimer");
    }
    IEnumerator DeleteTimer()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }
}
