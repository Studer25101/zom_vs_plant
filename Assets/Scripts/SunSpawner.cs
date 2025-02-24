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
        // 화면의 높이 = 카메라 뷰 포트의 크기 +/- @
        float maxScreenHeight = Camera.main.orthographicSize - 0.02f; //  4.92-> 4.9 
        float minScreenHeight = -(Camera.main.orthographicSize - 0.12f); //  -4.92 -> -4.8 

        // 종횡비 화면의 최대/최소 너비 -> 종횡비: '화면의 가로 / 화면의 세로'의 비율 ex) 16:9
        float maxScreenWidth = (maxScreenHeight * Screen.width / Screen.height) - 0.47f; // 8.71 -> 8.24 
        float minScreenWidth = minScreenHeight * Screen.width / Screen.height + 2.52f; //  -8.54 -> -6.02 

        // 드롭Y 높이 기준
        float DropPosY = maxScreenHeight - 0.63f; //  4.9-> 4.27 

        GameObject mySugar = Instantiate(sugarObject, new Vector3(Random.Range(minScreenWidth, maxScreenWidth), maxScreenHeight), Quaternion.identity);
        mySugar.GetComponent<sun>().dropToYPos = Random.Range(DropPosY, -DropPosY);

        Invoke("SpawnSugar", 7f);   // 생성 쿨타임
    }
}
