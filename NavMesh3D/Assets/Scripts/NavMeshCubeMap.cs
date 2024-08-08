using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class NavMeshCubeMap : MonoBehaviour
{
    public int gridSize = 10;                   //���� ���� ť�� ����
    public float cellSize = 1.0f;               //�� ť�� �� ũ��
    public float dropprobablity = 0.1f;         //ť�갡 ������ Ȯ��
    public float dropDuration = 3.0f;           //ť�갡 �������µ� �ɸ��� �ð�
    public float terrianChangeInterval = 10.0f; //���� ��ȭ ����
    public GameObject cubePrefabs;              //ť�� ������
    public NavMeshSurface surface;              //NavMesh�� ������ ǥ��
    public GameObject playerPrefab;             //�÷��̾� ������

    private GameObject[,] grid;                 //�׸��带 ������ 2���� �迭
    private GameObject player;                  //�÷��̾� ���� ������Ʈ
    private NavMeshAgent playerAgent;
    private float terrainChangeTimer;

    private struct DroppingCube
    {
        public GameObject cube;         //ť����� ������Ʈ
        public Vector3 startPos;        //���� ��ġ
        public Vector3 endPos;          //�� ��ġ
        public float dropTimer;
        public int x, z;                //�׸��� �� ��ġ
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
                Vector3 position = new Vector3(x * cellSize, 0 , z * cellSize); //�� ť�� ��ġ ���
                GameObject cube = Instantiate(cubePrefabs, position, Quaternion.identity);
                cube.transform.localScale = new Vector3(cellSize, cellSize, cellSize);
                grid[x, z] = cube;
            }
        }
    }
    void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(gridSize/2 * cellSize, cellSize, gridSize / 2 * cellSize);  //�׸��� �߾�
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

    

    void UpdateDroppingCubes()          //�������� ť��� ������Ʈ
    {
        for(int i = droppingCubes.Count - 1; i >= 0; i--)
        {
            DroppingCube droppingCube = droppingCubes[i];
            droppingCube.dropTimer += Time.deltaTime;

            if(droppingCube.dropTimer >= dropDuration)  //�������� �ð��� �Ϸ� �Ǹ�
            {
                Destroy(droppingCube.cube);
                grid[droppingCube.x, droppingCube.z] = null;
                droppingCubes.RemoveAt(i);  
            }
            else
            {
                droppingCube.cube.transform.position = Vector3.Lerp(droppingCube.startPos,droppingCube.endPos,
                    droppingCube.dropTimer / dropDuration);
                droppingCubes[i] = droppingCube;        //ť�� ��ġ ������Ʈ
            }
        }
    }
    void StartDropCube(int x, int z)        //ť�긦 ����߸��� ����
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
