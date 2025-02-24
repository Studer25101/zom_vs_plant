using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterController : MonoBehaviour
{
    // ��� ���� �͵�
    protected int HP; // ���� hp
    protected float coolTime;  // ��Ÿ��
    [SerializeField] protected SpriteRenderer spriteRenderer; // �ش� ������Ʈ ��������Ʈ
    [SerializeField] protected Animator animator; // �ش� ������Ʈ �ִϸ��̼�
    [SerializeField] protected LayerMask targetLayer; // �ش� ������Ʈ ���� Ÿ�� ���̾� | Ex) �÷��̾�(me) -> ����(target) 
    [SerializeField] protected RaycastHit2D hit;

    public int GetHp() { return HP; }
    public void SetHp(int value) { HP = value; }

    private bool isDamaged = false;


    protected void Start()
    {
        SetHp(HP);
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Debug.Log($"CharacterController �ʱ�ȭ �Ϸ�, {this.gameObject.name} ü��: {HP}");

        if(gameObject.layer == 12)
            targetLayer = LayerMask.GetMask("Target");
        else if(gameObject.layer == 9)
            targetLayer = LayerMask.GetMask("Sweet");
    }

    public void FixedUpdate()
    {
        //Debug.Log("Layer of this GameObject: " + LayerMask.LayerToName(gameObject.layer));

        Debug.Log($"{gameObject.name} ��ȭ hp: {GetHp()}");

        if (!isDamaged) // �浹���� �ʾ��� ��
        {
            Vector2 raycastdire = Vector2.zero;
            if (gameObject.layer == 9) // ȣ��
            {
                raycastdire = Vector3.left;
            }
            else if (gameObject.layer == 12) // ����
            {
                raycastdire = Vector3.right;
            }
            
            hit = Physics2D.Raycast(transform.position, raycastdire, 0.8f, targetLayer);
            Debug.DrawRay(transform.position, raycastdire * 0.8f, Color.green);

            // �Ϲ����� �浹 �ݶ��̴� ����
            if(hit.collider != null)
            {
                //Debug.Log("Hit: " + hit.collider.gameObject.name + " at position: " + hit.point);
                if(!isDamaged)
                {
                    isDamaged = true;
                    Bullet bullet = hit.collider.GetComponent<Bullet>();
                    zombie zombie = hit.collider.GetComponent<zombie>();

                    if(gameObject.layer == 9)
                    {
                        if(bullet != null)
                            Hit(bullet.GetDamage());
                    }                        
                    else if(gameObject.layer == 12)
                    {
                        if(zombie != null)
                            zombie.Hit(bullet.GetDamage(), bullet.freeze);
                    }
                }
            }
        }
    }

    private IEnumerator DamagedEffect()
    {
        OnDamaged();
        yield return new WaitForSeconds(0.5f);
        OffDamaged();
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }

    // �Ϲ����� �Ҹ��� 
    public void Hit(int damage)
    {
        HP -= damage;
        Debug.Log("Player Hit! Current Health: " + HP);
        // ���� ����
        StartCoroutine(DamagedEffect());

        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    void OnDamaged()
    {
        // View Alpha (�ǰ� �� ���� �ٲٱ�)
        spriteRenderer.color = new Color(1, 0, 0, 0.4f);
    }

    void OffDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}
