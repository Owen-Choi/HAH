using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChoose : MonoBehaviour
{
    public bool isLight;    public bool isFire;     public bool isSilver;
    public GameObject LightArrow;  public GameObject SilverArrow;  public GameObject FireArrow;
    public GameObject Follower1; public GameObject Follower2; public GameObject Follower3;
    void Awake()
    {
        if(isLight)
        {
            SilverArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Follower1.gameObject.SetActive(false);
            Follower2.gameObject.SetActive(false);
            Follower3.gameObject.SetActive(false);
        }
        else if(isSilver)
        {
            LightArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Follower1.gameObject.SetActive(false);
            Follower2.gameObject.SetActive(false);
            Follower3.gameObject.SetActive(false);
        }
        else if(isFire)
        {
            LightArrow.gameObject.SetActive(false);
            SilverArrow.gameObject.SetActive(false);
        }
    }

    
}
