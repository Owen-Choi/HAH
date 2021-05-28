using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Got_Burned : MonoBehaviour                             //�� ��ũ��Ʈ�� ����ִ� Got_Burned ��� ������Ʈ�� ��ȭ���� �������� ���� ��� SetActive(false)ó���� �� ��� �Ѵ�.
{                                                                   //�׷��� ���� ��� ���� �޸� ���� �ʷ��� ���ɼ��� �ִ�.
    SpriteRenderer sr;
    Light2D light;
    Animator anim;
    GameObject ParentObj;
    void Start()
    {
        anim = GetComponent<Animator>();
        light = GetComponent<Light2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        light.enabled = false;
        ParentObj = this.transform.parent.gameObject;                   //ĳ���� ���� �ڵ�. �������� �𸣰ڴ�.
    }

    
    void Update()
    {
        if(ParentObj.GetComponent<Zombie_Stat>().is_burned)          //�θ� ������Ʈ�� ��ũ��Ʈ���� is_burned ������ true�� �ٲ� ��� ȭ�� �ִϸ��̼� ���
        {
            sr.enabled = true;
            light.enabled = true;
            this.anim.SetBool("is_Burned", true);
        }

        if (!ParentObj.GetComponent<Zombie_Stat>().is_burned)        //������ false�� �ٲ� ��� �ִϸ��̼� ����
        {
            this.anim.SetBool("is_Burned", false);
            sr.enabled = false;
            light.enabled = false;
        }
    }
}
