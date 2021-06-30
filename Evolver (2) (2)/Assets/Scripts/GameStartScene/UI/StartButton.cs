using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartButton : MonoBehaviour
{
    public GameObject Game_Manager;
    public void Pressed()
    {
        Game_Manager.GetComponent<Game_Manager>().isStart = true;
    }
}
