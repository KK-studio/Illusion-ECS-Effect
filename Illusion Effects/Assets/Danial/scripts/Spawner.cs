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

   private void Start()
   {
      firstPos = prefab.transform.position.z;
      print(firstPos);
   }


   public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) =>
      dstManager.AddComponentData(entity, new spawner_component
      {
         prefab = conversionSystem.GetPrimaryEntity(prefab),
         lastPos = firstPos,
         timeToNext = 0
      });

   public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
   {
      referencedPrefabs.Add(prefab);
   }
}
