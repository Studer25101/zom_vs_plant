using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ ũ�� ����
public class ScaleToFitZombieSpawn : MonoBehaviour
{
    private SpriteRenderer sr; // ���ȭ�� ��������Ʈ

    private void FixedUpdate()
    {
        sr = GetComponent<SpriteRenderer>();

        // ȭ�� ����
        float worldScreenHeight = Camera.main.orthographicSize * 2;

        // ȭ�� �ʺ�
        float worldScreenWidth = (worldScreenHeight / Screen.height * Screen.width) / 5.0f;

        // ȭ�� ũ�� ����
        Vector3 Scale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x,
            worldScreenHeight / sr.sprite.bounds.size.y, 1);
        transform.localScale = Scale;
        print("ũ��:" + Scale);
        print($"WorldHeight: {worldScreenHeight}, WorldWidth: {worldScreenWidth}");
    }
}
