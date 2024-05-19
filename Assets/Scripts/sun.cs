using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class sun : MonoBehaviour
{
    private float dropToYPos; // Cost ��� Y ��ǥ
    private float speed = 1.0f; // �ӵ�

    private void Start()
    {
        // ȭ���� ���� = ī�޶� �� ��Ʈ�� ũ�� +/- @
        float maxScreenHeight = Camera.main.orthographicSize + 0.53f; // 4.92 -> 5.45
        float minScreenHeight = -Camera.main.orthographicSize - 0.53f;

        // ��Ⱦ�� ȭ���� �ִ�/�ּ� �ʺ� -> ��Ⱦ��: 'ȭ���� ���� / ȭ���� ����'�� ���� ex) 16:9
        float maxScreenWidth = (maxScreenHeight * Screen.width / Screen.height) - 1.49f; // 9.69 -> 8.2
        float minScreenWidth = (minScreenHeight * Screen.width / Screen.height) + 1.49f;

        // ���Y ���� ����
        float DropPosY = maxScreenHeight - 1.18f; // 5.25 -> 4.27
        print("dropPosY: " + DropPosY);

        print($"maxScreenHeight: {maxScreenHeight}, maxScreenWidth:{maxScreenWidth}");
        print($"minScreenHeight: {minScreenHeight}, minScreenWidth: {minScreenWidth}");

        // ȭ�� �� �ִ�/�ּ� ��ġ�� �������� �� ������Ʈ Cost�� ��ġ ����
        transform.position = new Vector2(Random.Range(minScreenWidth, maxScreenWidth), maxScreenHeight);
        // ��� ��ġ �������� ����
        dropToYPos = Random.Range(DropPosY, -DropPosY);
    }
    private void Update()
    {
        //print("DropToYPos: " + dropToYPos + "position: " + this.transform.position);

        // Cost dropToYPos ��ġ �̵�
        if (transform.position.y >= dropToYPos)
        {
            // ����
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }else if(transform.position.y <= dropToYPos)  
        {
            // 7�� �� ����
            Destroy(gameObject, 7f);
        } 
    }
}
