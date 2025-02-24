using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI ũ�� ����
public class ScaleToFitUI : MonoBehaviour
{
    [SerializeField] private RectTransform cardUIRectTransform; // CardUI ������Ʈ�� RectTransform ������Ʈ

    private void Update()
    {
        // Canvas�� ũ�⸦ ������
        Vector2 canvasSize = GetComponent<RectTransform>().sizeDelta;

        // CardUI�� �ʺ�
        float newWidth = canvasSize.x / 5f;
        // CardUI�� ����
        float newHeight = canvasSize.y;

        // ����
        // CardUI�� ũ��
        //float scale = newWidth / cardUIRectTransform.sizeDelta.x;

        // CardUI�� X, Y ũ�� ��
        float scaleX = newWidth / cardUIRectTransform.sizeDelta.x;
        float scaleY = newHeight / cardUIRectTransform.sizeDelta.y;

        // CardUI�� Scale�� ����
        cardUIRectTransform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
}

