using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    public bool isLoad;
    private void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameStart"))
        {
            if (isLoad)
            {
                SceneManager.LoadScene("MainScene");
                GameObject.Find("tutorial").gameObject.SetActive(false);
            }
        }
        DontDestroyOnLoad(this);
    }
    
}
