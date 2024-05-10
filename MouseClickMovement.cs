using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**/
public class MouseClickMovement : MonoBehaviour
{
    Vector3 destPos; //�������� ��ǥ
    Vector3 dir; //�������� ����
    Quaternion lookTarget; //��ǥ���� ���ƾ��ϴ� ��
    bool move = false; // ���� ���߱� ������ �������� �ʰ� �����

    public float moveSpeed; //ĳ���� �̵��ӵ�
    RaycastHit hit;
    Ray ray;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) //��Ŭ���� ����
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���� ��ǥ ����

            if (Physics.Raycast(ray, out hit))//Ŭ���� ���� ��ü�� �ִ��� �˻�&���� �ʱ�ȭ
            {
                print(hit.transform.name);//Ŭ���� ��� ���

                destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z); //��ǥ ��ġ �缳��

                dir = destPos - transform.position; //���� ��ġ���� ��ǥ��ġ���� ����

                lookTarget = Quaternion.LookRotation(dir);//��ǥ���� ���ƾ��ϴ� ���� ����
                move = true;
            }
        }

        if(Input.GetButtonDown("Standard"))
        {
            move = false;
        }

        Move();//Move ����
    }

    private void Move()
    {
        if (move)
        {
            dir = destPos - transform.position; //���� ��ġ���� ��ǥ��ġ���� ����
            lookTarget = Quaternion.LookRotation(dir);//��ǥ���� ���ƾ��ϴ� ���� ����
            transform.rotation = lookTarget; //Ŭ����ġ�� ȸ��
            transform.position += dir.normalized * Time.deltaTime * moveSpeed; //�̵��������� moveSpeed��ŭ �̵�


            if((transform.position - destPos).magnitude < Time.deltaTime * moveSpeed)
            {
                transform.position = destPos;
                
                move = false; 
            }
        }
    }
}
