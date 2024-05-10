using Common.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTIme;
    public float maxGameTIme = 2 * 10f;

    public BasicCharacter player;
    public ObjectPooler pool;
    public SpawnInfo spawnInfo;
    //public EnemyVariables variables;

    void Awake()
    {
        instance = this;
        
    }

    

    void Update()
    {
        gameTIme += Time.deltaTime;
        //Ÿ�̸� ������ ������ �ð� �ֱ�
        if (gameTIme > maxGameTIme) 
        {
            gameTIme = maxGameTIme; 
        }
    }
    //���� �ٸ� ��ũ��Ʈ�� �����ϱ� ���Ϸ��� ���� ���ӸŴ���
}
