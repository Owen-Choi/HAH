using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleGuideOff : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.activeSelf)
            StartCoroutine("Duration");
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
