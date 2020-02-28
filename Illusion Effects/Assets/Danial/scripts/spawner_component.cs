
using System;
using Unity.Collections;
using Unity.Entities;

[Serializable]
public struct spawner_component : IComponentData
{
  public Entity prefab;
  public float timeToNext;
  public float lastPos;
  public float lastPosY;
  public int max_index;
  public int min_index;
};