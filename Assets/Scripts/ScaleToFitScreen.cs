using UnityEngine;

// ȭ�� ũ�� ����
public class ScaleToFitScreen : MonoBehaviour
{
    private SpriteRenderer sr; // ���ȭ�� ��������Ʈ

    private void FixedUpdate()
    {
        sr = GetComponent<SpriteRenderer>();

        // ī�޶� �������� ȭ�� ���̿� �ʺ� ���ϱ�
        float worldScreenHeight = Camera.main.orthographicSize * 2; 
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // ȭ�� ũ�� ����
        Vector3 Scale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x,
            worldScreenHeight / sr.sprite.bounds.size.y, 1);
        transform.localScale = Scale;
        print("ũ��:" + Scale);
        print($"WorldHeight: {worldScreenHeight}, WorldWidth: {worldScreenWidth}");
    }
} // class