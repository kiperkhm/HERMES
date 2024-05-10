using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour
{
    public GameObject[] prefabs; // �ν����Ϳ��� �ʱ�ȭ

    List<GameObject>[] pools; //Ǯ�� ���� �������� �ޱ�����
    //private Dictionary<string, IObjectPool<GameObject>> ojbectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();
    //private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
            pools[index] = new List<GameObject>();
        //Ǯ �ʱ�ȭ
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])//foreach�� �˻�
        {
            if (!item.activeSelf) //��Ȱ��ȭ�� Ǯ�� �ִٸ� Ȱ��ȭ(������ �ִٸ�)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select) //��Ȱ��ȭ�� Ǯ�� ������ ���� ����
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }

    public void Clear(int index)
    {
        foreach (GameObject item in pools[index])
            item.SetActive(false);
    }

    public void ClearAll()
    {
        for (int index = 0; index < pools.Length; index++)
            foreach (GameObject item in pools[index])
                item.SetActive(false);
    }
}
