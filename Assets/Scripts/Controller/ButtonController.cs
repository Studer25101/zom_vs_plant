using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // ��ư Ŭ�� �� ȣ���� �޼ҵ�
    public void MainLoadScene()
    {
        // sceneToLoad ������ ����� �̸��� Scene�� �ε�
        SceneManager.LoadScene("MainGame");
    }

    public void MenuLoadScene()
    {
        // sceneToLoad ������ ����� �̸��� Scene�� �ε�
        SceneManager.LoadScene("GameMenu");
        Destroy(GameObject.Find("GameManager"));
    }

    public void NextLevelScene(int num)
    {
        SceneManager.LoadScene($"Level{num}");
    }
}
