using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : MonoBehaviour, IState<MonsterController>
{
    private MonsterController _monsterController;

    public void OperateEnter(MonsterController sender)
    {
        _monsterController = sender;

        Debug.Log("¸ÂÀ½");
        _monsterController.nav.enabled = false;
        _monsterController.health--;
        _monsterController.isHit = false;
        //StartCoroutine(isHit());
        
    }

    public void OperateUpdate(MonsterController sender)
    {

    }

    public void OperateExit(MonsterController sender)
    {
        StopAllCoroutines();
    }
}
