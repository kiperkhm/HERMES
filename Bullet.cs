using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;
    private Transform target;//�÷��̾� ĳ������ ������ �ٵ�
    private Vector3 targetPosition;
    Rigidbody rb;
    private void OnEnable()
    {
        bulletSpeed = 200f;
        rb = GetComponent<Rigidbody>();
        target = GameManager.instance.player.GetComponent<Transform>();
        //float dirx = target.transform.position.x - transform.position.x;
        //float dirz = target.transform.position.z - transform.position.z;
        //Vector3 dir = target.position - transform.position;
        //rb.AddForce(dirx * bulletSpeed, 0, dirz * bulletSpeed);
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
        rb.AddForce(transform.forward * bulletSpeed * 2f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);    // �� ��ü�� �ѹ��� 
        CancelInvoke();    // Monobehaviour�� Invoke�� �ִٸ� 
    }
}
