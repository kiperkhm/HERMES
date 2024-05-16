using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackState : MonoBehaviour, IState<MonsterController>
{
    private MonsterController _monsterController;
    private Transform AttackPoint;
    public void OperateEnter(MonsterController sender)
    {
        _monsterController = sender;
        AttackPoint = transform.GetChild(0);
        _monsterController.MoveAble = false;
        //Debug.Log("근접 공격");
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        AttackPoint.LookAt(_monsterController.target.transform);

        yield return new WaitForSeconds(_monsterController.beforCastDelay);
        _monsterController.anim.SetTrigger("Attack");
        _monsterController.MoveAble = false;
        yield return new WaitForSeconds(_monsterController.attackSpeed);
        //Debug.Log("발사");
        StartCoroutine(Fire());
    }
    public void OperateUpdate(MonsterController sender)
    {
        //Debug.Log("근접공격중");
    }

    public void OperateExit(MonsterController sender)
    {
        StopAllCoroutines();
        //Debug.Log("근접 공격 해제");
    }
}