using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTheme_UI : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public void FirstButtonPress()
    {
        // # �� ������ ���� �� �÷��̾ SpawnPoint�� �̵�.   SpawnPoint�� �������� ������ ���� ���� �ִ�.
        Instantiate(Resources.Load("Forest_Stage_1"));
        GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
    }

    // ���� ���� �������� Button�� �߰��ϱ�.
}
