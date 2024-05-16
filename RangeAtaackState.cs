using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : MonoBehaviour, IState<MonsterController>
{
    private MonsterController _monsterController;
    private Transform AttackPoint;
    public void OperateEnter(MonsterController sender)
    {
        _monsterController = sender;
        AttackPoint = transform.GetChild(0);

        //Debug.Log("원거리공격");
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        AttackPoint.LookAt(_monsterController.target.transform);
        yield return new WaitForSeconds(_monsterController.attackSpeed);
        //_monsterController.anim.SetTrigger("Attack");
        GameObject bulletA =    
                ObjectPooler.SpawnFromPool("bulletA", new Vector3(AttackPoint.transform.position.x, AttackPoint.transform.position.y, AttackPoint.transform.position.z));

        //Debug.Log("원거리발사");
        StartCoroutine(Fire());
    }
    public void OperateUpdate(MonsterController sender)
    {
        //Debug.Log("공격wnd");
    }

    public void OperateExit(MonsterController sender)
    {
        StopAllCoroutines();
        //Debug.Log("원거리공격 해제");
    }
}