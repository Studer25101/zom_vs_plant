using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CireDraw : MonoBehaviour
{
    public Vector2 boxSize = new Vector2(1, 1); // BoxCast�� ũ��
    public float boxAngle = 0; // BoxCast�� ����
    public Vector2 boxDirection = new Vector2(1, 0); // BoxCast�� ����
    public float boxDistance = 10; // BoxCast�� �Ÿ�
    public LayerMask layerMask; // BoxCast�� ������ ���̾�

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // BoxCast�� ���� ��ġ�� ǥ��
        Gizmos.DrawWireCube(transform.position, boxSize);

        // BoxCast�� ����� �Ÿ��� ǥ��
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)boxDirection.normalized * boxDistance);

        // BoxCast�� �����ϰ� ����� ����
        RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position, boxSize, boxAngle, boxDirection, boxDistance, layerMask);

        // BoxCast�� � �ݶ��̴��� �¾Ҵٸ�, �� ��ġ�� ǥ���ϰ� ��ü�� �̸��� ���
        if (hit.collider != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(hit.point, boxSize);

            // ��ü�� �̸��� �ֿܼ� ���
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
        }
    }
}
