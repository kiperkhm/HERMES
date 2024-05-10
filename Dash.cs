using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashPower;//�ѹ��� �뽬�� �Ÿ�
    public int dashNumberMax;//�ִ� ���Ӵ뽬 ��
    public int dashNumberNow;//���� �뽬 ���� ��
    public float dashResetTime;//�뽬 �ʱ�ȭ �ð�
    public float dashChargeTime;//�뽬 ���� �ð�
    private float tick;
    private Vector3 dashDestPos;//��ǥ ��ġ
    private Vector3 dashDestDir;//��ǥ ����
    private Quaternion dashDestRot;//��ǥ�� �ٶ󺸱� ���� ���ƾ��ϴ� ���� ũ��
    private RaycastHit hit;//��ǥ ��ǥ ����
    Ray ray;//����
    bool dashAble = false;

    public void Start()
    {
        dashNumberNow = dashNumberMax; //�뽬 �� �ʱ�ȭ
    }
    // Update is called once per frame
    public void Update()
    {
        dashAble = dashNumberNow > 0;

        if (Input.GetButtonDown("Dash"))//���Ű �Է½�
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);//���콺 ��ġ ����

            if (Physics.Raycast(ray, out hit))//��ǥ�� ������ ��
            {
                dashDestPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);//��ǥ��ġ ����
                dashDestDir = dashDestPos - transform.position;//��ǥ���� ����
                dashDestRot = Quaternion.LookRotation(dashDestDir);//�� ũ�� ����
                DashActive();//�뽬 ����
            }
        }
        Cooldown();
    }
    private void DashActive()
    {
        if (dashAble) //�뽬 �Է¹ް� & �뽬 ������ ��Ȳ�� ��
        {
            dashNumberNow--; //�뽬���� -1 
            transform.rotation = dashDestRot;//��ǥ�������� ȸ��
            transform.position += dashDestDir.normalized * dashPower;//dashPower��ŭ �̵�
        }
    }

    private void Cooldown()
    {
        if (dashNumberNow != dashNumberMax) // �뽬 ���� ��
        {
            tick += Time.deltaTime; // �ð� ��� ����

            if (dashChargeTime < tick) // ����Ÿ�� �Ѱ��� ��
            {
                tick = 0; //Ÿ�̸� �ʱ�ȭ
                dashNumberNow++; // �뽬 Ƚ�� �߰�
            }
        }

       
    }
}