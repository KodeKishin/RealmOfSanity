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

}



[Serializable]
public struct Skill : IComponentData{

    public int id;
    public float cooldown;
    public float requiredEnergy;
    public float requiredHealth;

    public float effectArea;


}


public enum SkllType{
    Melee,
    Shoot,
    Point,
    Homing,
    Passive
}

