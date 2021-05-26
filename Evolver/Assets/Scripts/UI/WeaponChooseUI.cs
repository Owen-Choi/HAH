using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChooseUI : MonoBehaviour
{
    public GameObject WeaponChoose;
    public Canvas WeaponUI;
    public Canvas BasicUI;
    // ������ ������ ���� �� �ϳ��� �����ϸ� BasicUI Ȱ��ȭ�ϰ� WeaponChoose ������Ʈ�� ���� �Ѱ��ְ� ���� ����

    private void Awake()
    {
        this.gameObject.SetActive(true);                            //�����ִ� ���¶� �ڱ� �ڽŵ� ��� ���ϳ�����. ���߿� gameManager ������Ʈ���� ����������� �� �ϴ�.
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
