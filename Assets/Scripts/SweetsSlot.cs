using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Sweet Slot�� ��ġ + UI
public class SweetsSlot : MonoBehaviour
{
    public Sprite sweetSprite;          // ���� ��������Ʈ
    public GameObject sweetObject;      // ����Ʈ ������Ʈ (��: ĵ��, ���ݸ� ��)

    public int price;                   // ����Ʈ�� ����

    public Image icon;                  // UI ������
    public TextMeshProUGUI priceText;   // UI ����

    private GameManager gms;

    private void Start()
    {
        // GameManager ������Ʈ�� ã�Ƽ� �װ����κ��� GameManager ������Ʈ�� ������
        gms = GameObject.Find("GameManager").GetComponent<GameManager>();

        // �� ������ Ŭ���Ǿ��� �� BuySweet �޼��带 ȣ���ϵ��� �̺�Ʈ �����ʸ� �߰�
        GetComponent<Button>().onClick.AddListener(BuySweet);
    }

    private void BuySweet()
    {
        if (gms.cost >= price && !gms.currentSweet)
        {
            gms.cost -= price;
            // GameManager�� BuySweet �޼��带 ȣ���Ͽ� �ش� ����Ʈ�� ����
            gms.BuySweet(sweetObject, sweetSprite);
        }

    }

    private void OnValidate()
    {
        // �����ܰ� �ؽ�Ʈ ������Ʈ
        if (sweetSprite)
        {
            icon.enabled = true;
            icon.sprite = sweetSprite;
            priceText.text = price.ToString();
        }
        else
        {
            // ������ ��Ȱ��ȭ
            icon.enabled = false;
        }
    }
}

