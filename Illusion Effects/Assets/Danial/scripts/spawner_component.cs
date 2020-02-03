
using System;
using Unity.Entities;

[Serializable]
public struct spawner_component : IComponentData
{
  public Entity prefab;
  public float timeToNext;
  public float lastPos;
};