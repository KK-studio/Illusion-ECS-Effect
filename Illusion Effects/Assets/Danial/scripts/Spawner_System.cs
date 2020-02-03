using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner_System : ComponentSystem
{

    protected override void OnUpdate()
    {
        Entities.ForEach((ref spawner_component myref) =>
        {

            myref.timeToNext -= Time.DeltaTime;
            if (myref.timeToNext < 0)
            {

                for (int i = 0; i < 50; i++)
                {
                    Entity entity = EntityManager.Instantiate(myref.prefab);
                    EntityManager.AddComponentData(entity,new Translation
                    {
                        Value = new float3(i,0,myref.lastPos)
                    });
                }
                myref.timeToNext =  1;
                myref.lastPos += 1;
            }
        });
    }
}
