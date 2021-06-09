using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crisis_Guide : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine("OFFDelay");
    }

    IEnumerator OFFDelay()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
