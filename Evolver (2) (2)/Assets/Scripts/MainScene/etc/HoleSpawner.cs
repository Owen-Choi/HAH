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
        GuideUICache.SetActive(true);                                   //�θ��� ������Ʈ�� �ı��ž �ڽĵ� �ı��� ���� OnDestroy�� ������ �ɱ�?
    }
}
