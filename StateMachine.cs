using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private T m_sender;

    //���� ���¸� ��� ������Ƽ
    public IState<T> CurState { get; set; }


    //�⺻ ���¸� �����ÿ� �����ϰ� ������ ����
    public StateMachine(T sender, IState<T> state)
    {
        m_sender = sender;
        SetState(state);
    }

    public void SetState(IState<T> state)
    {
        //Debug.Log("SetState : " + state);

        // null�������
        if (m_sender == null)
        {
            Debug.LogError("m_sender ERROR");
            return;
        }

        if (CurState == state)
        {
            //Debug.LogWarningFormat("Same state : ", state);
            return;
        }

        if (CurState != null)
            CurState.OperateExit(m_sender);

        //���� ��ü.
        CurState = state;

        //�� ������ Enter�� ȣ���Ѵ�.
        if (CurState != null)
            CurState.OperateEnter(m_sender);

        Debug.Log("SetNextState : " + state);

    }

    //State�� Update �Լ�.
    public void DoOperateUpdate()
    {
        if (m_sender == null)
        {
            Debug.LogError("invalid m_sener");
            return;
        }
        CurState.OperateUpdate(m_sender);
    }
}
