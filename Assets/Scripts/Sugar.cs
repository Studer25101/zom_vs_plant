using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : Sweet
{
    public GameObject sugarObject;

    new void Start()
    {
        sugarObject = Resources.Load<GameObject>("Prefabs/Cost/Suncost");
        Scurhp = 6;
        coolTime = 6;
        InvokeRepeating("SpawnSugar", coolTime, coolTime);
        base.Start();
    }

    // ���� ����
    void SpawnSugar()
    {
        GameObject mySuagar = Instantiate(sugarObject, new Vector3(transform.position.x + Random.Range(-.5f, .5f),
            transform.position.y + Random.Range(0f, .5f), 0), 
            Quaternion.identity);
        mySuagar.GetComponent<sun>().dropToYPos = transform.position.y - 1f;
    }
}
