using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class NavMeshCubeMap : MonoBehaviour
{
    public int gridSize = 10;                   //가로 세로 큐브 숫자
    public float cellSize = 1.0f;               //각 큐브 셀 크기
    public float dropprobablity = 0.1f;         //큐브가 떨어질 확률
    public float dropDuration = 3.0f;           //큐브가 떨어지는데 걸리는 시간
    public float terrianChangeInterval = 10.0f; //지형 변화 간격
    public GameObject cubePrefabs;              //큐브 프리팹
    public NavMeshSurface surface;              //NavMesh를 생성할 표면
    public GameObject playerPrefab;             //플레이어 프리팹

    private GameObject[,] grid;                 //그리드를 저장할 2차원 배열
    private GameObject player;                  //플레이어 게임 오브젝트
    private NavMeshAgent playerAgent;
    private float terrainChangeTimer;

    private struct DroppingCube
    {
        public GameObject cube;         //큐브게임 오브젝트
        public Vector3 startPos;        //시작 위치
        public Vector3 endPos;          //끝 위치
        public float dropTimer;
        public int x, z;                //그리드 내 위치
    }

    private List<DroppingCube> droppingCubes = new List<DroppingCube>();
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
        SpawnPlayer();
        surface.BuildNavMesh();
        terrainChangeTimer = terrianChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        HandleTerraionChanges();
        UpdateDroppingCubes();
    }
    void CreateGrid()
    {
        grid = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(x * cellSize, 0 , z * cellSize); //각 큐브 위치 계산
                GameObject cube = Instantiate(cubePrefabs, position, Quaternion.identity);
                cube.transform.localScale = new Vector3(cellSize, cellSize, cellSize);
                grid[x, z] = cube;
            }
        }
    }
    void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(gridSize/2 * cellSize, cellSize, gridSize / 2 * cellSize);  //그리드 중앙
        player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        playerAgent = player.GetComponent<NavMeshAgent>();
    }
    void HandleTerraionChanges()
    {
        terrainChangeTimer -= Time.deltaTime;
        if (terrainChangeTimer <= 0 )
        {
            bool terrainChange = false;

            for(int x = 0; x < gridSize; x++)
            {
                for(int z = 0; z < gridSize; z++)
                {
                    if(Random.value < dropprobablity && grid[x,z] != null)
                    {
                        StartDropCube(x,z);
                        terrainChange = true;
                    }
                }
            }

            if(terrainChange)
            {
                StartCoroutine(BakeMapNavMesh());
            }
            terrainChangeTimer = terrianChangeInterval;
        }
    }

    IEnumerator BakeMapNavMesh()
    {
        yield return new WaitForSeconds(0.2f);
        surface.BuildNavMesh();
    }

    

    void UpdateDroppingCubes()          //떨어지는 큐브들 업데이트
    {
        for(int i = droppingCubes.Count - 1; i >= 0; i--)
        {
            DroppingCube droppingCube = droppingCubes[i];
            droppingCube.dropTimer += Time.deltaTime;

            if(droppingCube.dropTimer >= dropDuration)  //떨어지는 시간이 완료 되면
            {
                Destroy(droppingCube.cube);
                grid[droppingCube.x, droppingCube.z] = null;
                droppingCubes.RemoveAt(i);  
            }
            else
            {
                droppingCube.cube.transform.position = Vector3.Lerp(droppingCube.startPos,droppingCube.endPos,
                    droppingCube.dropTimer / dropDuration);
                droppingCubes[i] = droppingCube;        //큐브 위치 업데이트
            }
        }
    }
    void StartDropCube(int x, int z)        //큐브를 떨어뜨리기 시작
    {
        GameObject cube = grid[x, z];
        Vector3 startPos = cube.transform.position;
        Vector3 endPos = startPos - Vector3.up * 5;

        droppingCubes.Add(new DroppingCube
        {
            cube = cube,
            startPos = startPos,
            endPos = endPos,
            dropTimer = 0,
            x = x,
            z = z
        });
    }
}
