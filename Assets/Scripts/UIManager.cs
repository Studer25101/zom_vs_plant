using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    private GameObject[] gradeobjs; // CardUI�� Card���� �迭

    private int grade = 0; // ���
    private const int maxGrade = 3; // �ִ� ���

    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // �� ��ȯ�� �����ǵ���
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        // GameOver UI ��Ȱ��ȭ
        GameObject.Find("Fade").SetActive(false);


        gradeobjs = new GameObject[9];
        for (int i = 0; i < 9; i++)
        {
            string gradePath = $"Canvas/UI/CardUI/Card{i}/Grade";
            gradeobjs[i] = GameObject.Find(gradePath);


            //print($"Card{i}");
            if (gradeobjs[i] == null)
            {
                Debug.LogWarning("Grade�� ã�� �� �����ϴ�: " + gradePath);
            }
            // ��Ȱ��ȭ
            Image image = gradeobjs[i].GetComponentInChildren<Image>();
            Text text = gradeobjs[i].GetComponentInChildren<Text>();
            if (image != null && text != null)
            {
                image.enabled = false;
                text.enabled = false;
            }
        }
    }

    // ����� ������Ű�� �Լ�
    public void GradeUpgrade()
    {
        if (grade < maxGrade)
        {
            grade++;
            UpdateGrade();
        }
    }

    // ��� Grade�� Text�� �����ϴ� �Լ�
    public void SetGradeText(string newText)
    {
        foreach (GameObject obj in gradeobjs)
        {
            if (obj != null)
            {
                Text text = obj.GetComponentInChildren<Text>();
                if (text != null)
                {
                    text.text = newText;
                }
                else
                {
                    Debug.LogWarning("Text ������Ʈ�� ã�� �� �����ϴ�: " + obj.name);
                }
            }
        }
    }

    // Grade Update
    public void UpdateGrade()
    {
        // Ȱ��ȭ
        for (int i = 0; i < gradeobjs.Length; i++)
        {
            if (i < gradeobjs.Length && gradeobjs[i] != null)
            {
                Image image = gradeobjs[i].GetComponentInChildren<Image>();
                Text text = gradeobjs[i].GetComponentInChildren<Text>();
                if (image != null && text != null)
                {
                    image.enabled = true;
                    text.enabled = true;
                }
            }
        }
    }

    // Grade ���� ��ȯ
    public int GetGrade()
    {
        return grade;
    }
}

