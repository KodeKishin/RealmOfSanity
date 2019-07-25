using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct Race : IComponentData
{
  public Entity target;
  public float health;
  public float energy;
  public float speed;
  public float size;

}



[Serializable]
public struct Skill : IComponentData{

    public Entity owner;
    public SkillType type;

    public float cooldown;
    public float requiredEnergy;
    public float requiredHealth;

    public float effectArea;

}


public enum SkillType{
    Melee,
    Shoot,
    Point,
    Homing,
    Passive
}

