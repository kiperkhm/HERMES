using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, IState<MonsterController>
{
    private MonsterController _monsterController;
    private Transform AttackPoint;
    public Transform Rotation;
    public void OperateEnter(MonsterController sender)
    {
        _monsterController = sender;
        AttackPoint = transform.GetChild(0);
        _monsterController.MoveAble = false;
        //_monsterController.navObs.enabled = true;
        //_monsterController.navObs.carving = true;
        //Debug.Log("근접 공격");
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        AttackPoint.LookAt(_monsterController.target.transform);

        yield return new WaitForSeconds(_monsterController.beforCastDelay);
        _monsterController.anim.SetTrigger("Attack");
        _monsterController.MoveAble = false;
        Debug.Log("발사");
        yield return new WaitForSeconds(_monsterController.attackSpeed);
        StartCoroutine(Fire());
    }
    public void OperateUpdate(MonsterController sender)
    {
        //Debug.Log("근접공격중");
    }

    public void OperateExit(MonsterController sender)
    {
        //_monsterController.navObs.carving = false;
        //_monsterController.navObs.enabled = false;
        StopAllCoroutines();
        _monsterController.anim.SetBool("Attack1", true);
        //Debug.Log("근접 공격 해제");
    }
}