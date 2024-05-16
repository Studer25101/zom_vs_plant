using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // ������ ���� ������
    public Transform[] spawnPoints; // ���� ������ ��ġ �迭
    public Transform[] spawnTiles; // ���� ������ Ÿ�� �迭

    public float zombieSpeed = 3f; // ������ �̵� �ӵ�

    private float spawnInterval = 5f; // ���� ���� ����
    private float nextSpawnTime = 0f; // ���� ���� �ð�

    private void Update()
    {
        // ���� �ð��� ���� ���� �ð����� ũ�ų� ������ ���� ����
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    // ���� ���� �޼���
    private void SpawnZombie()
    {
        // ������ Ÿ�� ����
        int randomTileIndex = Random.Range(0, spawnTiles.Length);
        // ����ߴµ� ���� �𸣰ڽ��ϴ� -> Spawn Points �� Spawn Tile�� Element(index)���� ���� �ʾƼ� ������ ��̴ϴ�.
        /* ���� Ÿ���� Transfrom �����ϱ� ������ �ذ�ǳ׿�.
         �׸��� ���̰� �ƴ϶� �ش� �̸��� ������Ʈ��ã�Ƽ� Ramdom���� ������ �ǰ� �ؾ� �� �� ���ƿ�.
         -> randomTileIndex�� ���ؼ� �������� ������ �ش� ������Ʈ�� ��ġ�� ��Ÿ���� �ؾ� �� �� ���ƿ�.
         ex) randomTileIndex = 5 , zomMakeTile5�� �̸��� ���� ������Ʈ�� ã�Ƽ� 
             zomMake5�� Trasnfrom ��ġ�� ���� ����
        */
        Transform selectedTile = spawnTiles[randomTileIndex];

        // ������ spawnPoint ���� -> �굵 ���������� Element�� �־��ּ���.
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // ���� ���� ��ġ�� ������ Ÿ���� ��ġ�� ����
        Vector3 spawnPosition = selectedTile.position;

        // ���� ����
        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

        // ���� �������� �̵��ϵ��� Rigidbody2D�� �ӵ� ����
        Rigidbody2D rb = newZombie.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-zombieSpeed, 0f);
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on zombie prefab.");
        }
    }
}