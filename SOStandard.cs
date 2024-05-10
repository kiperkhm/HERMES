using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOStandard : ScriptableObject
{
    public string SkillName;

    public float Damage;
    public float Cooltime;
    public float SkillDistance;
    public float SkillDuration;

    public Animation Animation;
    public Sprite Icon;

    public static bool isEnabled;

}
