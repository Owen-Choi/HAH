using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Got_Burned : MonoBehaviour                             //이 스크립트를 담고있는 Got_Burned 라는 오브젝트는 불화살을 선택하지 않을 경우 SetActive(false)처리를 해 줘야 한다.
{                                                                   //그렇지 않을 경우 심한 메모리 낭비를 초래할 가능성이 있다.
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
        ParentObj = this.transform.parent.gameObject;                   //캐싱을 위한 코드. 먹힐지는 모르겠다.
    }

    
    void Update()
    {
        if(ParentObj.GetComponent<Zombie_Stat>().is_burned)          //부모 오브젝트의 스크립트에서 is_burned 변수가 true로 바뀔 경우 화상 애니메이션 재생
        {
            sr.enabled = true;
            light.enabled = true;
            this.anim.SetBool("is_Burned", true);
        }

        if (!ParentObj.GetComponent<Zombie_Stat>().is_burned)        //변수가 false로 바뀐 경우 애니메이션 중지
        {
            this.anim.SetBool("is_Burned", false);
            sr.enabled = false;
            light.enabled = false;
        }
    }
}
