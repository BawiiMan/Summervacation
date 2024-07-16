using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float viewRadius = 5.0f;                                         //시야 거리 5
    public float viewAngle = 90f;                                           //시야 각도 90도
    public LayerMask enemyLayer;                                            //적 레이어    

    public List<Transform> detectedEnemies = new List<Transform>();         //시야 안에 들어온 적 리스트

    // Update is called once per frame
    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()                      //적군 탐색 하는 함수
    {
        detectedEnemies.Clear();

        Collider[] enemiesInRadius = Physics.OverlapSphere(transform.position, viewRadius, enemyLayer);    //시야 거리 내에 있는 모든 컬라이더를 가져온다.

        foreach(Collider enemyCollider in enemiesInRadius)                                      //enemiesInRadius 배열을 순환한다.
        {
            Transform enemy = enemyCollider.transform;                                          //위치 값을 가진 Transform값을 가져온다.
            Vector3 directionToEnemy = (enemy.position - transform.position).normalized;        //적을 향한 방향 Vector 값

            float dotProduct = Vector3.Dot(transform.forward, directionToEnemy);                //내적 사용
            float viewThreshold = Mathf.Cos(viewAngle * 0.5f * Mathf.Deg2Rad);

            if(dotProduct > viewThreshold)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);           //적과 나와의 거리를 구한다.
                //레이어 마스크 : ~enemyLayer를 사용하여 적 레이어를 제외한 모든 레이어 체크
                if(!Physics.Raycast(transform.position, directionToEnemy, distanceToEnemy, ~enemyLayer))
                {
                    detectedEnemies.Add(enemy);
                    Debug.Log("적 탐지 : " + enemy.name);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;                                  //시야 범위는 파란색 선
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Gizmos.color = Color.yellow;
        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);

        //부채꼴 모양 그리기
        Vector3 prevPoint = transform.position + viewAngleA * viewRadius;
        for(float angle = -viewAngle / 2; angle <= viewAngle / 2; angle += 5)
        {
            Vector3 newPoint = transform.position + DirFromAngle(angle, false) * viewRadius;
            prevPoint = newPoint;
        }
    }

    Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
