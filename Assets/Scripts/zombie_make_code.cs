using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_make_code : MonoBehaviour
{

    public int[] tiempos;

    public GameObject Zombie;

    void Start()
    {
        for (int i = 0; i < tiempos.Length; i++)
        {
            Invoke("InstanciarZombie", tiempos[i]);
        }
    }
    void InstanciarZombie()
    {
        // ���� ����.rotation -> ȸ�� �Ұ��� X
        Instantiate(Zombie, transform.position, Quaternion.identity);
    }
}
