using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacterMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; // NavMeshAgent 컴포넌트 참조

    void Start()
    {
        // NavMeshAgent 컴포넌트를 가져옴
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // 마우스 우클릭 입력을 감지하고 해당 위치로 캐릭터를 이동시킴
        if (Input.GetMouseButtonDown(1))
        {
            MoveToClickPoint();
        }
    }

    // 마우스 우클릭한 위치로 캐릭터를 이동시키는 메서드
    void MoveToClickPoint()
    {
        // 마우스 우클릭한 위치를 Ray로 변환
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Ray가 NavMesh와 충돌하는지 확인
        if (Physics.Raycast(ray, out hit))
        {
            // NavMesh 상의 해당 위치로 캐릭터 이동 명령을 내림
            navMeshAgent.SetDestination(hit.point);
        }
    }
}
