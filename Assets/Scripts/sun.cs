using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public float dropToYPos; // Cost ��� Y ��ǥ
    private float speed = 1.0f; // �ӵ�

    private void Start()
    {
        
    }
    private void Update()
    {
        // Cost dropToYPos ��ġ �̵�
        if (transform.position.y >= dropToYPos)
        {
            // ����
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            // dropToYPos���� �Ʒ��� �����ϸ� GameObject ����
            Destroy(gameObject, 7f);
        }
    }
}
