using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct move_component : IComponentData
{
    public float maxPos;
    public int dir;
    public float time_to_be_active;
    public bool active;
   
}
