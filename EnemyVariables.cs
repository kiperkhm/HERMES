using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariables : MonoBehaviour
{
    public enum MonsterType
    {
        BasicMeleeAttack,
        BasicRangeAttack,
        BasicSummoner,
    }
    public MonsterType type;

    public string enemyType = "Null";
    public float Original_Health = 0;
    public float Original_Speed = 0;
    public float Attack_Range = 0;
    public float Attack_Speed = 0;
    public float before_cast_delay = 0;
    /*
    void OnEnable()
    {
        switch (type)
        {
            case MonsterType.BasicMeleeAttack:
                //enemyType = "BasicMeleeAttack";
                //OriginalHealth = 20f;
                //OriginalSpeed = 3f;
                //AttackRange = 2.5f;
                //AttackSpeed = 3f;
                break;
            case MonsterType.BasicRangeAttack:
                //enemyType = "BasicRangeAttack";
                //OriginalHealth = 10f;
                //OriginalSpeed = 1.5f;
                //AttackRange = 8f;
                //AttackSpeed = 3f;
                break;
            case MonsterType.BasicSummoner:
                //enemyType = "BasicSummoner";
                //OriginalHealth = 20f;
                //OriginalSpeed = 3f;
                //AttackRange = 2.5f;
                //AttackSpeed = 1f;
                break;
        }
        //Debug.Log
    }
    
    // _monsterController.original
    */
}
