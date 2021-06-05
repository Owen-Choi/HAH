using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapUI : MonoBehaviour
{
    public Canvas ForestTheme;
    public Canvas SchoolTheme;
    public Canvas CityTheme;
    public Canvas BasicUI;

    private void Awake()
    {
        // # ���� UI�� ���ִ� ���ȿ��� �ٸ� UI�� ��Ȱ��ȭ
        BasicUI.gameObject.SetActive(false);    
    }
    public void FirstButtonPress()
    {
        // # MapChoose UI�� ��Ȱ��ȭ �ϰ� �ش� ��ư�� �׸� UI�� Ȱ��ȭ
        this.transform.parent.gameObject.SetActive(false);
        ForestTheme.gameObject.SetActive(true);                         //�� �׸��� ��ũ��Ʈ���� �ؾ��� ��� : �������� ������ ���� �� �÷��̾� �̵�, �ٽ� �⺻ UI ����
    }

    public void SecondButtonPress()
    {
        this.transform.parent.gameObject.SetActive(false);
        SchoolTheme.gameObject.SetActive(true);
    }
    public void ThridButtonPress()
    {
        this.transform.parent.gameObject.SetActive(false);
        CityTheme.gameObject.SetActive(true);
    }

}
