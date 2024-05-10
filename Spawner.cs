using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    
    //���� ���� ����Ʈ�Է�
    int RoomCode;//���� ������ ����
    float timer; //time.deltatime�� �ֱ����� ����
    int typeNum = 0;
    int spawnPointNum;
    

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        
    }

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject enemySquare = ObjectPooler.SpawnFromPool("EnemySquare", Vector2.zero);
            //Spawner.GetComponent<SpawnData>().SpawnData(health);
            //Spawn(GameManager.instance.spawnInfo.type[typeNum], GameManager.instance.spawnInfo.num, GameManager.instance.spawnInfo.point, GameManager.instance.spawnInfo.type[typeNum].Length);
        }
        
    }
    public void SpawnStart()
    {
        //Spawn(GameManager.instance.spawnInfo.type[typeNum], GameManager.instance.spawnInfo.num, GameManager.instance.spawnInfo.point, GameManager.instance.spawnInfo.type[typeNum].Length);
        Spawn();
    }
    void Spawn()
    {
        //case "EnemySquare":
        Debug.Log("��������");
        
        for (int i = 0; i < spawnData.Length; i++)
        {
            Debug.Log(spawnData.Length);
            for (int j = 0; j < spawnData[typeNum].num; j++)
            {
                GameObject enemy =
                    ObjectPooler.SpawnFromPool(spawnData[typeNum].spriteType, new Vector3(spawnPoint[spawnPointNum].transform.position.x, spawnPoint[spawnPointNum].transform.position.y, spawnPoint[spawnPointNum].transform.position.z));

                //enemy.GetComponent<EnemyMove>().Init(spawnData[0]);
                //enemy.GetComponent<enemyHealth>().Init(spawnData[0]);
            }
            typeNum++;
            //enemy.GetComponent<EnemyMove>().Init(spawnData[0]);
            //enemy.GetComponent<enemyHealth>().Init(spawnData[0]);
        }
        
    }
}

[System.Serializable]
public class SpawnData
{
    public string spriteType;
    public int type;
    public int num;

}


