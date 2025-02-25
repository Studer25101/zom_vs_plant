/*
�浹�� ����Ʈ ������� �ڵ� (��Ƽ��) or 1ȸ ����

 �浹�� ����Ʈ ����� �ڷ� 0.5�� �и��� ����� 
0.5f �� ���Ƿ� �����ؼ� �ð��� ���� + ����Ʈ�� �������� ���� ����Ʈ �־ 0.X�� ����� ������� ���� �ڵ��Դϴ�.
 

 
 
 */

using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public ParticleSystem explosionParticle; // ��ƼŬ �ý����� ������ ����

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� ã���ϴ�.
        GameObject otherObject = collision.gameObject;

      

  
        // �� ��ũ��Ʈ�� ���Ե� ������Ʈ�� ������ ���:
         Destroy(gameObject, 5.5f);
    }

    void PlayExplosionEffect()
    {
        // ��ƼŬ �ý����� Ȱ��ȭ�Ͽ� ȿ���� ����մϴ�.
        explosionParticle.Play();
    }
}
