using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    float radius = 1f;
    public GameObject DisplayBed;
    GameObject BedCache;
    RaycastHit2D circle;
    private void Awake()
    {
        BedCache = DisplayBed;
        BedCache.SetActive(true);
    }
    void Update()
    {
        circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("PlayerInShelter"));

        if (circle && !BedCache.transform.GetChild(1).gameObject.activeSelf)
        {
            BedCache.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveSystem.SaveItem();
                SaveSystem.SavePhysicalSkill();
                SaveSystem.SaveSkill();
                SaveSystem.SaveStat();
                BedCache.transform.GetChild(0).gameObject.SetActive(false);
                BedCache.transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine("vanishing");
            }
        }
        else
            BedCache.transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator vanishing()
    {
        yield return new WaitForSeconds(3f);
        BedCache.transform.GetChild(1).gameObject.SetActive(false);

    }
}
