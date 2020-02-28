using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour,IConvertGameObjectToEntity,IDeclareReferencedPrefabs
{

   public GameObject prefab;
   private float firstPos;
   private float firstPosY;

   private void Start()
   {
      firstPos = prefab.transform.position.z;
      firstPosY = prefab.transform.position.x;

   }


   public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) =>
      dstManager.AddComponentData(entity, new spawner_component
      {
         prefab = conversionSystem.GetPrimaryEntity(prefab),
         lastPos = firstPos,
         timeToNext = 0,
         max_index = 0,
         min_index = 0,
        // myEntity = new int[100][],
         lastPosY = firstPosY
      });

   public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
   {
      referencedPrefabs.Add(prefab);
   }
}
