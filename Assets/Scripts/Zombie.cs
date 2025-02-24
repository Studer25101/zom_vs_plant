using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zombie : CharacterController
{ 
    // 추가
    [SerializeField] public float speed = 0.5f;
    [SerializeField] public int damage = 1;
    [SerializeField] public int Pcurhp = 10;

    private bool canEat = true;

    public Sweet targetSweet;
    // -------------------

    public int vida = 4;
    public float velocidad;

    public float cadencia = 1f;

    protected new void Start()
    {
        // 추가
        gameObject.layer = 9;
        HP = Pcurhp;
        coolTime = 0.0f;
        base.Start();
    }

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .7f, targetLayer);
        Debug.DrawRay(transform.position, Vector3.left * .7f, Color.red);

        if(hit.collider != null)
        {
            targetSweet = hit.collider.GetComponent<Sweet>();
            Eat(damage, coolTime);
        }
        else
            animator.SetBool("Hit", false);

        if(!targetSweet)
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        
    }

   public void Eat(int damage, float delay)
    {
        if(!canEat || !targetSweet)
            return;
        canEat = false;
        animator.SetBool("Hit", true);
        StartCoroutine(ResetEatCooldown(delay));
   }

    IEnumerator ResetEatCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        canEat = true;
    }

    public int GetDamage()
    {
        return damage;
    }

    // 추가
    public void Hit(int damage, bool freeze)
    {
        this.HP -= damage;
        if(freeze)
            OnFreeze();
       else
            OffFreeze();

        if(this.HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // 추가
    void OnFreeze()
    {
        CancelInvoke("UnFreeze");
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        speed = speed / 2f;
        Invoke("UnFreeze", 0.5f);
    }

    // 추가
    void OffFreeze()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.4f);
        Invoke("UnFreeze", 0.5f);
    }

    // 추가
    void UnFreeze()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}