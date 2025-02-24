using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject sugarObject;

    private void Start()
    {
        SpawnSugar();
    }

    void SpawnSugar()
    {
        // ȭ���� ���� = ī�޶� �� ��Ʈ�� ũ�� +/- @
        float maxScreenHeight = Camera.main.orthographicSize - 0.02f; //  4.92-> 4.9 
        float minScreenHeight = -(Camera.main.orthographicSize - 0.12f); //  -4.92 -> -4.8 

        // ��Ⱦ�� ȭ���� �ִ�/�ּ� �ʺ� -> ��Ⱦ��: 'ȭ���� ���� / ȭ���� ����'�� ���� ex) 16:9
        float maxScreenWidth = (maxScreenHeight * Screen.width / Screen.height) - 0.47f; // 8.71 -> 8.24 
        float minScreenWidth = minScreenHeight * Screen.width / Screen.height + 2.52f; //  -8.54 -> -6.02 

        // ���Y ���� ����
        float DropPosY = maxScreenHeight - 0.63f; //  4.9-> 4.27 

        GameObject mySugar = Instantiate(sugarObject, new Vector3(Random.Range(minScreenWidth, maxScreenWidth), maxScreenHeight), Quaternion.identity);
        mySugar.GetComponent<sun>().dropToYPos = Random.Range(DropPosY, -DropPosY);

        Invoke("SpawnSugar", 7f);   // ���� ��Ÿ��
    }
}
