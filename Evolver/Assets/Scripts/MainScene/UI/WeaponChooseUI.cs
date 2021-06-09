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
    // ������ ������ ���� �� �ϳ��� �����ϸ� BasicUI Ȱ��ȭ�ϰ� WeaponChoose ������Ʈ�� ���� �Ѱ��ְ� ���� ����

    private void Awake()
    {
        this.gameObject.SetActive(true);                            //�����ִ� ���¶� �ڱ� �ڽŵ� ��� ���ϳ�����. ���߿� gameManager ������Ʈ���� ����������� �� �ϴ�.
        ChargingUI.gameObject.SetActive(true);
        GMCache = GameManager;
    }
    public void FirstButtonPress()
    {
        Time.timeScale = 1;
        GMCache.GetComponent<Game_Manager>().SkillChosen = true;
        WeaponChoose.GetComponent<WeaponChoose>().isLight = true;
        BasicUI.gameObject.SetActive(true);
        ChargingUI.transform.GetChild(0).gameObject.SetActive(true);    //��¡ UI�� ù��° �ڽ�(�淮ȭ��)�� Ȱ��ȭ
        Destroy(ChargingUI.transform.GetChild(1).gameObject);           //�ι�° �ڽ�(��ȭ��)�� �ı�
        Destroy(ChargingUI.transform.GetChild(2).gameObject);           //����° �ڽ�(��ȭ��)�� �ı�
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
