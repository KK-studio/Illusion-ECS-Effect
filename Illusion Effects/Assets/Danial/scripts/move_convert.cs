using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class move_convert : MonoBehaviour,IConvertGameObjectToEntity
{

    public float maxPos;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new move_component
        {
            dir = 1,
            maxPos = maxPos,
            
        });
    }
}
