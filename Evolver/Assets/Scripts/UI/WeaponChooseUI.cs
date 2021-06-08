using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChooseUI : MonoBehaviour
{
    public GameObject WeaponChoose;
    public Canvas WeaponUI;
    public Canvas BasicUI;
    public GameObject ChargingUI;

    public GameObject GameManager;
    GameObject GMCache;
    // 세가지 유형의 무기 중 하나를 선택하면 BasicUI 활성화하고 WeaponChoose 오브젝트에 정보 넘겨주고 게임 시작

    private void Awake()
    {
        this.gameObject.SetActive(true);                            //꺼져있는 상태라 자기 자신도 제어를 못하나보다. 나중에 gameManager 오브젝트에서 제어해줘야할 듯 하다.
        ChargingUI.gameObject.SetActive(true);
        GMCache = GameManager;
    }
    public void FirstButtonPress()
    {
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        WeaponChoose.GetComponent<WeaponChoose>().isLight = true;
        BasicUI.gameObject.SetActive(true);
        ChargingUI.transform.GetChild(0).gameObject.SetActive(true);    //차징 UI의 첫번째 자식(경량화살)을 활성화
        Destroy(ChargingUI.transform.GetChild(1).gameObject);           //두번째 자식(은화살)은 파괴
        Destroy(ChargingUI.transform.GetChild(2).gameObject);           //세번째 자식(불화살)도 파괴
        Destroy(this.gameObject);
    }

    public void SecondButtonPress()
    {
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        WeaponChoose.GetComponent<WeaponChoose>().isSilver = true;
        BasicUI.gameObject.SetActive(true);
        ChargingUI.transform.GetChild(1).gameObject.SetActive(true);
        Destroy(ChargingUI.transform.GetChild(0).gameObject);
        Destroy(ChargingUI.transform.GetChild(2).gameObject);
        Destroy(this.gameObject);
    }

    public void LastButtonPress()
    {
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        WeaponChoose.GetComponent<WeaponChoose>().isFire = true;
        BasicUI.gameObject.SetActive(true);
        ChargingUI.transform.GetChild(2).gameObject.SetActive(true);
        Destroy(ChargingUI.transform.GetChild(0).gameObject);
        Destroy(ChargingUI.transform.GetChild(1).gameObject);
        Destroy(this.gameObject);
    }
}
