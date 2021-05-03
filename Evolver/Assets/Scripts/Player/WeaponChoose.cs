using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChoose : MonoBehaviour
{
    public bool isLight;    public bool isFire;     public bool isSilver;
    public GameObject SkillChoose;
    public GameObject LightArrow;  public GameObject SilverArrow;  public GameObject FireArrow;
    public GameObject Follower1; public GameObject Follower2; public GameObject Follower3;
    void Update()
    {
        if(isLight)
        {
            SilverArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Follower1.gameObject.SetActive(false);
            Follower2.gameObject.SetActive(false);
            Follower3.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 1;
            SkillChoose.GetComponent<SkillChoose>().MinValue = 6;
            Destroy(this.gameObject);                       //�̷��� ������Ʈ�� �����Ϸ��� SkillChoose�� MinValue�� MaxValue�� �ٸ� ��ũ��Ʈ���� �������־�� �Ѵ�.
        }
        else if(isSilver)
        {
            LightArrow.gameObject.SetActive(false);
            FireArrow.gameObject.SetActive(false);
            Follower1.gameObject.SetActive(false);
            Follower2.gameObject.SetActive(false);
            Follower3.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 15;
            SkillChoose.GetComponent<SkillChoose>().MinValue = 19;
            Destroy(this.gameObject);
        }
        else if(isFire)
        {
            LightArrow.gameObject.SetActive(false);
            SilverArrow.gameObject.SetActive(false);
            SkillChoose.GetComponent<SkillChoose>().MinValue = 25;
            SkillChoose.GetComponent<SkillChoose>().MinValue = 29;
            Destroy(this.gameObject);
        }
    }

    
}

