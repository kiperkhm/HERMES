using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacterMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; // NavMeshAgent ������Ʈ ����

    void Start()
    {
        // NavMeshAgent ������Ʈ�� ������
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ���콺 ��Ŭ�� �Է��� �����ϰ� �ش� ��ġ�� ĳ���͸� �̵���Ŵ
        if (Input.GetMouseButtonDown(1))
        {
            MoveToClickPoint();
        }
    }

    // ���콺 ��Ŭ���� ��ġ�� ĳ���͸� �̵���Ű�� �޼���
    void MoveToClickPoint()
    {
        // ���콺 ��Ŭ���� ��ġ�� Ray�� ��ȯ
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Ray�� NavMesh�� �浹�ϴ��� Ȯ��
        if (Physics.Raycast(ray, out hit))
        {
            // NavMesh ���� �ش� ��ġ�� ĳ���� �̵� ����� ����
            navMeshAgent.SetDestination(hit.point);
        }
    }
}
