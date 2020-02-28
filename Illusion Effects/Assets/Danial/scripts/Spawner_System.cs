using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner_System : ComponentSystem
{
    protected override void OnCreate()
    {
        
        base.OnCreate();

    }

    private bool check = false;
    protected override void OnUpdate()
    {
        if (check)
        {
            
        }
        else
        {
            Entities.ForEach((ref spawner_component myref) =>
            {

                float x = myref.lastPos;
                Debug.Log(myref.lastPosY);
                float y = myref.lastPosY;

           //     EntityManager.CreateArchetype(ref move_component);
                for (int i = 0; i < 100; i++)
                {
                    //myref.myEntity[i] = new int[100];
                    for (int j = 0; j < 100; j++)
                    {
                        Entity entity = EntityManager.Instantiate(myref.prefab);
                        EntityManager.AddComponentData(entity, new Translation
                        {
                            Value = new float3(myref.lastPosY, 0, myref.lastPos)
                        });
                        // myref.myEntity[i][j] = entity.Index;
                        myref.lastPos += 1;
                    }

                    myref.lastPos = x;
                    myref.lastPosY++;
                }
                //myref.timeToNext =  1;

                check = true;
            });
        }
    }
}
