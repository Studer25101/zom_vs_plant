using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    readonly int tilesNum = 10; // 스폰 위치 갯수
    
    public GameObject[] zombiePrefabs; // 좀비 랜덤 생성 프리팹
    public Transform spawnPoints; // 좀비가 생성될 위치 배열
    public Transform[] spawnTiles; // 좀비가 생성될 타일 배열

    private readonly float spawnInterval = 10f; // 좀비 생성 간격
    private float nextSpawnTime = 0f; // 다음 생성 시간

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
        // 현재 시간이 다음 생성 시간보다 크거나 같으면 좀비 생성
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    // 좀비 생성 메서드
    private void SpawnZombie()
    {
        // 랜덤 시드 값 설정
        long randomSeed = System.DateTime.Now.Ticks;
        Random.InitState((int)randomSeed % int.MaxValue);

        // 랜덤한 타일 선택
        int randomTileIndex = Random.Range(0, spawnTiles.Length);
        Transform selectedTile = spawnTiles[randomTileIndex];
        Debug.Log($"랜덤 타일 Index: {randomTileIndex}, 스폰한 좀비 종류: {selectedTile.name}");

        //Debug.Log($"랜덤 시드 값: {randomSeed}, 랜덤 스폰 타일: {randomTileIndex}");

        // 랜덤한 좀비 프리팹 선택 (추가)
        int randomZombieIndex = Random.Range(0, zombiePrefabs.Length);
        GameObject zombiePrefab = zombiePrefabs[randomZombieIndex];

        Debug.Log($"랜덤 좀비 Index: {randomZombieIndex}, 스폰한 좀비 종류: {zombiePrefab.name}");

        // 좀비 생성 위치를 선택한 타일의 위치로 설정
        Vector3 spawnPosition = selectedTile.position;

        // 좀비 생성
        Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

    }
}