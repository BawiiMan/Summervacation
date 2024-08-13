using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class AreaFloorBaker : MonoBehaviour
{
    [SerializeField] private NavMeshSurface Surface;        //NavMesh 생성에 사용될 Surface        
    [SerializeField] private GameObject Player;             //NavMesh가 플레이어 오브젝트
    [SerializeField] private float UpdateRate = 0.1f;       //NavMesh 업데이트 주기
    [SerializeField] private float MovementThredshold = 3f;  //NavMesh를 다시 생성할 플레이어 이동 거리 임계값
    [SerializeField] private Vector3 NavMeshSize = new Vector3(20, 20, 20); //NavMesh 크기

    private Vector3 WorldAnchor;                                                //NavMesh 중심점
    private NavMeshData navMeshData;                                            //NavMesh 데이터
    private List<NavMeshBuildSource> Sources = new List<NavMeshBuildSource>();  //NavMesh 생성에 사용될 소스

    void Start()
    {
        navMeshData = new NavMeshData();
        NavMesh.AddNavMeshData(navMeshData);
        BuildNavMesh(false);
        StartCoroutine(CheckPlayerMovement());
    }

    //플레이어 움직임 체크
    private IEnumerator CheckPlayerMovement()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);

        while (true)
        {
            //플레이어가 일정 거리 이상 이동했는지 체크
            if(Vector3.Distance(WorldAnchor, Player.transform.position) > MovementThredshold)
            {
                BuildNavMesh(true);
                WorldAnchor = Player.transform.position;
            }
            yield return Wait;
        }
    }


    private void BuildNavMesh(bool Async)           //NavMesh 생성 메서드
    {
        //NavMesh 경계 설정
        Bounds navMeshBounds = new Bounds(Player.transform.position, NavMeshSize);
        List<NavMeshBuildMarkup> markups = new List<NavMeshBuildMarkup>();
        List<NavMeshModifier> modifiers;

        //NavMeshModifier 컴포넌트 수집
        if(Surface.collectObjects == CollectObjects.Children)
        {
            modifiers = new List<NavMeshModifier>(GetComponentsInChildren<NavMeshModifier>());
        }
        else
        {
            modifiers = NavMeshModifier.activeModifiers;
        }

        //NavMeshBuildMarkUp설정
        for (int i = 0; i < modifiers.Count; i++)
        {
            if(((Surface.layerMask & (1 << modifiers[i].gameObject.layer)) == 1) &&
                modifiers[i].AffectsAgentType(Surface.agentTypeID))
            {
                markups.Add(new NavMeshBuildMarkup()
                {
                    root = modifiers[i].transform,
                    overrideArea = modifiers[i].overrideArea,
                    area = modifiers[i].area,
                    ignoreFromBuild = modifiers[i].ignoreFromBuild,
                }); 
            }
        }

        //NavMesh 소스 수집
        if(Surface.collectObjects == CollectObjects.Children)
        {
            NavMeshBuilder.CollectSources(transform, Surface.layerMask, Surface.useGeometry, Surface.defaultArea, markups, Sources);
        } else
        {
            NavMeshBuilder.CollectSources(navMeshBounds, Surface.layerMask, Surface.useGeometry, Surface.defaultArea, markups, Sources);
        }

        //NavMeshAgent 컴포넌트가 있는 소스를 제거
        Sources.RemoveAll(Sources => Sources.component != null && Sources.component.gameObject.GetComponent<NavMeshAgent>() != null);

        //NavMesh 데이터 업로드 (비동기, 동기)
        if(Async)
        {
            NavMeshBuilder.UpdateNavMeshDataAsync
                (navMeshData, Surface.GetBuildSettings(), Sources, new Bounds(Player.transform.position, NavMeshSize));
        }
        else
        {
            NavMeshBuilder.UpdateNavMeshData
                (navMeshData, Surface.GetBuildSettings(), Sources, new Bounds(Player.transform.position, NavMeshSize));
        }
    }
}
