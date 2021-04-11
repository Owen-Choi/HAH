using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver_Arrow : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        time += Time.deltaTime;
        if (time > 0.5f)
            Destroy(this.gameObject);
    }
}
