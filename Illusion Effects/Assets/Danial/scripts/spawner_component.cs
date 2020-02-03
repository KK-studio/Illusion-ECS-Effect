
using Unity.Entities;


public struct spawner_component : IComponentData
{
  public Entity prefab;
  public float timeToNext;
  public float lastPos;
};