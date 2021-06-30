using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Dead : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
}
