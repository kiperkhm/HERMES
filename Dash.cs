using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashPower;//한번에 대쉬할 거리
    public int dashNumberMax;//최대 연속대쉬 수
    public int dashNumberNow;//현재 대쉬 가능 수
    public float dashResetTime;//대쉬 초기화 시간
    public float dashChargeTime;//대쉬 충전 시간
    private float tick;
    private Vector3 dashDestPos;//목표 위치
    private Vector3 dashDestDir;//목표 방향
    private Quaternion dashDestRot;//목표를 바라보기 위해 돌아야하는 각의 크기
    private RaycastHit hit;//목표 좌표 측정
    Ray ray;//레이
    bool dashAble = false;

    public void Start()
    {
        dashNumberNow = dashNumberMax; //대쉬 수 초기화
    }
    // Update is called once per frame
    public void Update()
    {
        dashAble = dashNumberNow > 0;

        if (Input.GetButtonDown("Dash"))//대시키 입력시
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스 위치 대입

            if (Physics.Raycast(ray, out hit))//목표를 구했을 때
            {
                dashDestPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);//목표위치 설정
                dashDestDir = dashDestPos - transform.position;//목표방향 설정
                dashDestRot = Quaternion.LookRotation(dashDestDir);//돌 크기 설정
                DashActive();//대쉬 실행
            }
        }
        Cooldown();
    }
    private void DashActive()
    {
        if (dashAble) //대쉬 입력받고 & 대쉬 가능한 상황일 때
        {
            dashNumberNow--; //대쉬개수 -1 
            transform.rotation = dashDestRot;//목표방향으로 회전
            transform.position += dashDestDir.normalized * dashPower;//dashPower만큼 이동
        }
    }

    private void Cooldown()
    {
        if (dashNumberNow != dashNumberMax) // 대쉬 썼을 때
        {
            tick += Time.deltaTime; // 시간 계산 시작

            if (dashChargeTime < tick) // 리셋타임 넘겼을 때
            {
                tick = 0; //타이머 초기화
                dashNumberNow++; // 대쉬 횟수 추가
            }
        }

       
    }
}