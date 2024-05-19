using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // 20
    public float speed = 1.5f;

    private void Update()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Zombie ��ũ��Ʈ�� Hit �Լ��� ���� ��
        if(other.TryGetComponent<zombie>(out zombie zombie))
        {
            // ȣ������ Hit ���
            zombie.Hit(damage);
            Destroy(gameObject);
        }
    }
}
