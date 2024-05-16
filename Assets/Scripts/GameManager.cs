using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ������Ʈ�� ���¸� ������ ���� ����
    private static GameManager instance; 
    // �߰� 
    public GameObject currentSweet; 
    public Sprite currentSweetSprite;
    public Transform tiles; // Ÿ�� �θ� ������Ʈ�� transform
    public LayerMask tileMask; // Ÿ�� Ŭ���ϱ� ���� ���̾� ����ũ

    // ���� ī�� ������Ʈ
    public GameObject originalCard; // ���� ī�� ���� ������

    // ���� ���� ������Ʈ, �̹��� ����
    public void BuySweet(GameObject sweet, Sprite sprite)
    {
        currentSweet = sweet;
        currentSweetSprite = sprite;
    }

    void Awake()
    {
        // w�ߺ�����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� ���� ������Ʈ�� �ı�X
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ� ����
        }
    }

    // �߰�
    private void Update()
    {
        // ī�޶󿡼� ���콺 ��ġ�� ����ĳ��Ʈ ��� Ÿ���� ã��.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        // ��� Ÿ���� ��������Ʈ ��Ȱ��ȭ
        foreach (Transform tile in tiles)
            tile.GetComponent<SpriteRenderer>().enabled = false;
        
        // �����ɽ�Ʈ�� Ÿ���� ���߰� ���� sweet�� �ִ� ���
        if(hit.collider && currentSweet)
        {
            // Ÿ�Ͽ� ���� sweet�� ��������Ʈ �����ϰ� Ȱ��ȭ
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentSweetSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            // ���콺 ���� Ŭ���ϰ� Ÿ�Ͽ� sweet�� ���� ���
            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasSweet)
            {
                // ���� ����Ʈ�� �ش� ��ġ�� �����ϰ� Ÿ�Ͽ� ����Ʈ�� �ִ� ������ ����
                Instantiate(currentSweet, hit.collider.transform.position, Quaternion.identity);
                hit.collider.GetComponent<Tile>().hasSweet = true;
                currentSweet = null;
                currentSweetSprite = null;
            }
        }
    }
}