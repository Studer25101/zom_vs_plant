using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    readonly int tilesNum = 10; // ���� ��ġ ����
    
    public GameObject[] zombiePrefabs; // ���� ���� ���� ������
    public Transform spawnPoints; // ���� ������ ��ġ �迭
    public Transform[] spawnTiles; // ���� ������ Ÿ�� �迭

    private readonly float spawnInterval = 10f; // ���� ���� ����
    private float nextSpawnTime = 0f; // ���� ���� �ð�

    private void Start()
    {
        zombiePrefabs = Resources.LoadAll<GameObject>("Prefabs/Characters/Pumpkin");

        spawnPoints = GameObject.Find("zombie_make_object").transform;

        spawnTiles = new Transform[tilesNum];
        for(int i = 0; i < spawnTiles.Length; i++)
        {
            spawnTiles[i] = GameObject.Find($"zomMake{i + 1}").transform;
        }
        
    }

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
        // ���� �õ� �� ����
        long randomSeed = System.DateTime.Now.Ticks;
        Random.InitState((int)randomSeed % int.MaxValue);

        // ������ Ÿ�� ����
        int randomTileIndex = Random.Range(0, spawnTiles.Length);
        Transform selectedTile = spawnTiles[randomTileIndex];
        Debug.Log($"���� Ÿ�� Index: {randomTileIndex}, ������ ���� ����: {selectedTile.name}");

        //Debug.Log($"���� �õ� ��: {randomSeed}, ���� ���� Ÿ��: {randomTileIndex}");

        // ������ ���� ������ ���� (�߰�)
        int randomZombieIndex = Random.Range(0, zombiePrefabs.Length);
        GameObject zombiePrefab = zombiePrefabs[randomZombieIndex];

        Debug.Log($"���� ���� Index: {randomZombieIndex}, ������ ���� ����: {zombiePrefab.name}");

        // ���� ���� ��ġ�� ������ Ÿ���� ��ġ�� ����
        Vector3 spawnPosition = selectedTile.position;

        // ���� ����
        Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

    }
}