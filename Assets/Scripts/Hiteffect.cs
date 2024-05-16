using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiteffect : MonoBehaviour
{
    public GameObject hitEffectPrefab; // �ǰ� ����Ʈ ������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǰ� ó��
        if (collision.CompareTag("Bullet"))
        {
            // �ǰ� ����Ʈ ����
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

            // ���� ��� �ִϸ��̼� ���� ����ϴ� �ڵ� �߰�
            // �̵� ���� ���� ó���� ����

            // �ǰݵ� ���� ����
            Destroy(gameObject);
        }
    }
}
