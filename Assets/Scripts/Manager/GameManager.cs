using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ������Ʈ�� ���¸� ������ ���� ����
    private static GameManager instance;
    // �߰� 
    public GameObject currentSweet;
    [SerializeField] private GameObject newSweet;
    private Collider2D lastHitTile; // ������ Ŭ�� Ÿ��
    public Sprite currentSweetSprite;

    public Transform tiles; // Ÿ�� �θ� ������Ʈ�� transform
    public LayerMask tileMask; // Ÿ�� Ŭ���ϱ� ���� ���̾� ����ũ

    // ���� ī�� ������Ʈ
    public GameObject originalCard; // ���� ī�� ���� ������

    public int cost = 100;
    public TextMeshProUGUI costText;

    public LayerMask costMask;

    private UIManager UIManager;

    // ���� ���� ������Ʈ, �̹��� ���� (�߰�)
    public void BuySweet(GameObject sweet, Sprite sprite)
    {
        currentSweet = sweet;
        currentSweetSprite = sprite;
    }

    void Awake()
    {
        // w�ߺ�����
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� ���� ������Ʈ�� �ı�X
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ� ����
        }
    }

    private void Start()
    {
        tiles = GameObject.Find("Slots").transform;
        tileMask = LayerMask.GetMask("Tiles");
        costText = GameObject.Find("CostText").GetComponent<TextMeshProUGUI>();
        //originalCard = GameObject.Find("Card0");
        costMask = LayerMask.GetMask("Cost");
    }

    // �߰�
    private void Update()
    {
        costText.text = cost.ToString();

        // ī�޶󿡼� ���콺 ��ġ�� ����ĳ��Ʈ ��� Ÿ���� ã��.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        // ��� Ÿ���� ��������Ʈ ��Ȱ��ȭ
        foreach(Transform tile in tiles)
            tile.GetComponent<SpriteRenderer>().enabled = false;

        
        // �����ɽ�Ʈ�� Ÿ���� ���߰� ���� sweet�� �ִ� ���
        if(hit.collider && currentSweet)
        {
            //Debug.Log("hit collider: " + hit.collider.name + "current Sweet: " + currentSweet.name);
            // Ÿ�Ͽ� ���� sweet�� ��������Ʈ �����ϰ� Ȱ��ȭ
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentSweetSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            // ���콺 ���� Ŭ���ϰ� Ÿ�Ͽ� sweet�� ���� ���
            if(Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasSweet)
            {
                // ���� ����Ʈ�� �ش� ��ġ�� �����ϰ� Ÿ�Ͽ� ����Ʈ�� �ִ� ������ ����
                newSweet = Instantiate(currentSweet, hit.collider.transform.position, Quaternion.identity);
                hit.collider.GetComponent<Tile>().hasSweet = true;


                currentSweet = null;
                currentSweetSprite = null;

                // �ٸ� Ÿ�ϵ��� ��������Ʈ�� null�� ����
                foreach(Transform tile in tiles)
                {
                    if(tile != hit.collider.transform)
                    {
                        tile.GetComponent<SpriteRenderer>().sprite = null;
                    }
                }

                lastHitTile = hit.collider;
            }
        }
        else if(lastHitTile && newSweet.IsDestroyed()) // ������ ������(=Sweet)�� �����Ǿ��� �� ������ ����.
        {
            // Ÿ�ϵ��� ��������Ʈ�� null�� ����
            foreach(Transform tile in tiles)
            {
                if(tile != lastHitTile.transform)
                {
                    tile.GetComponent<SpriteRenderer>().sprite = null;
                }
            }
            lastHitTile.GetComponent<Tile>().hasSweet = false;
        }

        // Sugar Ŭ�� �� Cost ����
        RaycastHit2D costhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, costMask);

        if(costhit.collider)
        {
            if(Input.GetMouseButtonDown(0))
            {
                cost += 25;
                Destroy(costhit.collider.gameObject);
            }
        }

        // Grade Upgrade �� Text �Է�
        UIManager.Instance.SetGradeText(UIManager.Instance.GetGrade().ToString());
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.GradeUpgrade();
        }
    }
}