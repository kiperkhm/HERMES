using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseMove : MonoBehaviour
{
    public float orginSpeed;//나중에 플레이어가 느려지는 상황 대비해서 원래 속도와 현재속도 구별
    public float curSpeed;
    NavMeshAgent agent;     //네비매쉬
    //Animator anim;
    public Transform spot;  //마우스 클릭시 클릭 위치 표시를 위해 과녁모양가져오기

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
                agent.SetDestination(hit.point);    //이동
                
                spot.gameObject.SetActive(true);
                spot.position = hit.point;
            }
        }

        if(agent.remainingDistance < 0.1f)
        {
            //정지시 애니메이션 넣으면 됨
            spot.gameObject.SetActive(false);
        }
    }
}
