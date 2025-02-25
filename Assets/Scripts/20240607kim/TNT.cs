using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class TNT : Sweet
{
    [SerializeField] private Vector2 boxSize = new (4f, 4f);
    public float delay = 1.2f; // ���� �� ��� �ð�
    //public float destructionRadius = 1f; // �ı� �ݰ�(����)
    public float delayBeforeDestroy = 2f; // �ı� �� ��� �ð�
    public LayerMask TargetLayer; // �߰�

    new void Start()
    {
        Scurhp = 99999;
        Invoke("Bomb", delay);
        base.Start();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ����
        /*// �浹�� ������Ʈ�� ã���ϴ�.
        //GameObject otherObject = collision.gameObject; 

        // �ֺ��� ��� ������Ʈ�� ã���ϴ�.
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, destructionRadius);

        // �浹�� ������Ʈ�� ã���ϴ�.
        GameObject otherObject = collision.gameObject;

        // �ֺ��� ��� ������Ʈ�� ã���ϴ�.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, TargetLayer);

        // �浹�� ������Ʈ�� ���� ������ ������Ʈ�� ã�Ƽ� �ı��մϴ�.
        foreach (Collider2D collider in colliders)
        {
            // �浹�� ������Ʈ�� ���� ������ ������Ʈ���� Ȯ���մϴ�.
            if (collider.gameObject.tag == otherObject.tag)
            {
                // 2�� �Ŀ� ������Ʈ�� �����մϴ�.
                Destroy(collider.gameObject, delayBeforeDestroy);
            }
        }

        // �ڱ� �ڽŵ� 2�� �Ŀ� �����մϴ�.
        Destroy(gameObject, delayBeforeDestroy);*/
    }

    // �߰�
    // Scene���� ���� ������Ʈ�� ã�� ���� OnDrawGizoms ���
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);

        // OverlapBoxAll�� �����Ͽ� �ڽ� ���� ���� ��� ������Ʈ�� ã���ϴ�.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, TargetLayer);

        // �� ������Ʈ�� ��ġ�� ǥ���մϴ�.
        foreach (Collider2D collider in colliders)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(collider.transform.position, collider.bounds.size);

            Destroy(collider.gameObject, 1f);
        }

        Destroy(gameObject, delayBeforeDestroy);
    }

    void Bomb()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Bomb");
        }
    }
}

