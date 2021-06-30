using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public GameObject Game_Manager;
    public void Pressed()
    {
        Game_Manager.GetComponent<Game_Manager>().isLoad = true;
    }
}
