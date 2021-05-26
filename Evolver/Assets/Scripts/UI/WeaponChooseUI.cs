using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChooseUI : MonoBehaviour
{
    public GameObject WeaponChoose;
    public Canvas WeaponUI;
    public Canvas BasicUI;
    // 세가지 유형의 무기 중 하나를 선택하면 BasicUI 활성화하고 WeaponChoose 오브젝트에 정보 넘겨주고 게임 시작

    private void Awake()
    {
        this.gameObject.SetActive(true);                            //꺼져있는 상태라 자기 자신도 제어를 못하나보다. 나중에 gameManager 오브젝트에서 제어해줘야할 듯 하다.
    }
    public void FirstButtonPress()
    {
        WeaponChoose.GetComponent<WeaponChoose>().isLight = true;
        BasicUI.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

    public void SecondButtonPress()
    {
        WeaponChoose.GetComponent<WeaponChoose>().isSilver = true;
        BasicUI.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

    public void LastButtonPress()
    {
        WeaponChoose.GetComponent<WeaponChoose>().isFire = true;
        BasicUI.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
