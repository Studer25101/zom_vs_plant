using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public float dropToYPos; // Cost 드롭 Y 좌표
    private float speed = 1.0f; // 속도

    private void Start()
    {
        
    }
    private void Update()
    {
        // Cost dropToYPos 위치 이동
        if (transform.position.y >= dropToYPos)
        {
            // 낙하
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            // dropToYPos보다 아래에 도달하면 GameObject 제거
            Destroy(gameObject, 7f);
        }
    }
}
