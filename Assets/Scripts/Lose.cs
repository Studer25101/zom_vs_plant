using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerEnter2D(Collider2D other)
    {
        float time = Time.timeScale;    // ���� ���� ����

        // ���� ���� �� + ȣ�ڰ� �浹
        if(other.gameObject.layer == 9 && time == 1)
        {
            // Game Over UI Ȱ��ȭ �� �ִϸ��̼� ���
            GameObject.Find("Death").transform.Find("Fade").gameObject.SetActive(true);
            ani.Play("DieAni");

            float endaniTime = ani.GetCurrentAnimatorStateInfo(0).length;

            // CardUI ��Ȱ��ȭ
            GameObject.Find("UI").SetActive(false);

            StartCoroutine(Interrupt(endaniTime));          
        }
    }

    IEnumerator Interrupt(float time)
    {
        yield return new WaitForSeconds(time);

        // ȭ�� ����
        Time.timeScale = 0;
    }

}
