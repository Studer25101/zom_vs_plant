using System.Collections;
using UnityEngine;

public class EatPudding : Sweet
{
    [SerializeField] private Vector2 boxSize = new Vector2(2f, 2f);
    private bool _isDamaged = false;

    new void Start()
    {
        Scurhp = 6;
        coolTime = 10f;
        base.Start();
    }

    // Scene���� ���� ������Ʈ�� ã�� ���� OnDrawGizoms ���
    void OnDrawGizmos()
    {
        if(_isDamaged == false)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, boxSize);

            // OverlapBoxAll�� �����Ͽ� �ڽ� ���� ���� ��� ������Ʈ�� ã���ϴ�.
            Collider2D colliders = Physics2D.OverlapBox(transform.position, boxSize, 0f, targetLayer);

            if(colliders != null)
            {
                _isDamaged = true;
                Destroy(colliders.gameObject);
                animator.SetBool("Damaged", true);
                Eat();
            }
        }
    }

    void Eat()
    {
        animator.SetTrigger("Eat");
        StartCoroutine(Eating(coolTime));
    }

    IEnumerator Eating(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("isEating", true);
        _isDamaged = false;
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Damaged", false);
        animator.SetBool("isEating", false);
    }
}
