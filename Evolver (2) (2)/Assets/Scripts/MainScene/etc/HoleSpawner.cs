using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HoleSpawner : MonoBehaviour
{
    GameObject GuideUICache;
    GameObject HoleCache;
    private void Start()
    {
        GuideUICache = GameObject.Find("Guide").transform.GetChild(0).gameObject;
        HoleCache = GameObject.Find("HoleToShelter").gameObject;
        HoleCache.SetActive(false);
    }

    private void OnDestroy()
    {
        HoleCache.SetActive(true);
        GuideUICache.SetActive(true);                                   //부모의 오브젝트가 파괴돼어서 자식도 파괴될 때도 OnDestroy가 적용이 될까?
    }
}
