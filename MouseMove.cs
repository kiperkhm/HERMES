using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseMove : MonoBehaviour
{
    public float orginSpeed;//���߿� �÷��̾ �������� ��Ȳ ����ؼ� ���� �ӵ��� ����ӵ� ����
    public float curSpeed;
    NavMeshAgent agent;     //�׺�Ž�
    //Animator anim;
    public Transform spot;  //���콺 Ŭ���� Ŭ�� ��ġ ǥ�ø� ���� �����簡������

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        agent.speed = orginSpeed;
        curSpeed = orginSpeed;
        agent.updateRotation = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);    //�̵�
                
                spot.gameObject.SetActive(true);
                spot.position = hit.point;
            }
        }

        if(agent.remainingDistance < 0.1f)
        {
            //������ �ִϸ��̼� ������ ��
            spot.gameObject.SetActive(false);
        }
    }
}
