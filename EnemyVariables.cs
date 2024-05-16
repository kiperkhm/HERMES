using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public UnitCode unitCode { get; }
    public string name { get; set; }
    public int maxHp { get; set; }
    public int curHp { get; set; }
    public int Damage { get; set; }
    public float originalSpeed { get; set; }
    public float AttackRange { get; set; }
    public float AttackSpeed { get; set; }
    public float beforeCastDelay { get; set; }

    public Stat()
    {

    }

    public Stat(UnitCode unitCode, string name, int maxHp, int damage, float originalSpeed, float attackRange, float attackSpeed, float beforeCastDelay)
    {
        this.unitCode = unitCode;
        this.name = name;
        this.maxHp = maxHp;
        curHp = maxHp;
        this.Damage = damage;
        this.originalSpeed = originalSpeed;
        this.AttackRange = attackRange;
        this.AttackSpeed = attackSpeed;
        this.beforeCastDelay = beforeCastDelay;
    }

    public Stat SetUnitStat(UnitCode unitCode)
    {
        Stat stat = null;

        switch(unitCode)
        {
            case UnitCode.Vengeful_Warrior: //�̸�, �ִ�ü��, ���ݷ�, �ӵ�, ���ݹ���, ���ݼӵ�, ���� _����
                stat = new Stat(unitCode, "Vengeful_Warrior", 150, 20, 5f, 2f, 2f, 2f);
                break;
            case UnitCode.Grudge_Archer:
                stat = new Stat(unitCode, "Grudge_Archer", 100, 20, 4f, 6f, 2f, 4f);
                break;
            case UnitCode.BasicSummoner:
                stat = new Stat(unitCode, "BasicSummoner", 100, 20, 6f, 3f, 2f, 8f);
                break;
            case UnitCode.Slime:
                stat = new Stat(unitCode, "Slime", 300, 20, 2f, 2f, 2f, 8f);
                break;
        }
        return stat;
    }
}
