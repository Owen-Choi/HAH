using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChoose : MonoBehaviour
{
    public bool isLight;    public bool isFire;     public bool isSilver;
    public GameObject SkillChoose; 
    public GameObject LightArrow;  public GameObject SilverArrow;  public GameObject FireArrow;
    public GameObject Middle_Right_ShotPoint; public GameObject Middle_Left_ShotPoint; public GameObject Full_Right_ShotPoint; public GameObject Full_Left_ShotPoint;
    public GameObject Follower1; public GameObject Follower2; public GameObject Follower3;

    void Update()
    {
        if(isLight)
        {
            Player_Stat.instance.isLight = true;
            SilverArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Middle_Left_ShotPoint.gameObject.SetActive(false);
            Middle_Right_ShotPoint.gameObject.SetActive(false);
            Full_Left_ShotPoint.gameObject.SetActive(false);
            Full_Right_ShotPoint.gameObject.SetActive(false);
            Follower1.gameObject.SetActive(false);
            Follower2.gameObject.SetActive(false);
            Follower3.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 1;
            SkillChoose.GetComponent<SkillChoose>().MaxValue = 8;
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().sprites = Resources.LoadAll<Sprite>("Light_Arrow_SkillIcon");
            Destroy(this.gameObject);                       //이렇게 오브젝트를 삭제하려면 SkillChoose의 MinValue와 MaxValue를 다른 스크립트에서 수정해주어야 한다.
        }
        else if(isSilver)
        {
            Player_Stat.instance.isSilver = true;
            LightArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Follower1.gameObject.SetActive(false);
            Follower2.gameObject.SetActive(false);
            Follower3.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 15;
            SkillChoose.GetComponent<SkillChoose>().MaxValue = 24;
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().sprites = Resources.LoadAll<Sprite>("Silver_Arrow_SkillIcon");
            Destroy(this.gameObject);
        }
        else if(isFire)
        {
            Player_Stat.instance.isFire = true;
            LightArrow.gameObject.SetActive(false);
            SilverArrow.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 25;
            SkillChoose.GetComponent<SkillChoose>().MaxValue = 32;
            GameObject.Find("SkillChoose").GetComponent<SkillChoose>().sprites = Resources.LoadAll<Sprite>("Fire_Arrow_SkillIcon");
            Destroy(this.gameObject);
        }
    }

    
}

