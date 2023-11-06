using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct InitializeBasketsSystem : ISystem
{   
    public List<GameObject> basketList;
    [BurstCompile]
    // Start is called before the first frame update
    public void OnUpdate(ref SystemState state)
    {
        // Will run only once
        state.Enabled = false;

        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<BasketProperties>>())
        {
            basketList = new LinkedEntityGroup;
            for (int i = 0; i < properties.ValueRO.numBaskets; i++)
            {
                // Instantiate the prefab Entity
                var instance = ecb.Instantiate(properties.ValueRO.basketEntity);
                basketList.Add(instance);
                // Note: the returned instance is only relevant when used in the ECB
                // as the entity is not created in the EntityManager until ECB.Playback
                var pos = Vector3.zero;
                pos.y = properties.ValueRO.basketBottomY + (properties.ValueRO.basketSpacingY * i);
                instance.transform.position = pos;
                basketList.Add(instance);


            }
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}