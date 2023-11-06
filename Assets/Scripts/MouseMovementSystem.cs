using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Burst;
using Unity.Mathematics;

//public partial struct MouseMovementSystem : ISystem
//{
//    [BurstCompile]
//    // Start is called before the first frame update
//    public void OnUpdate(ref SystemState state)
//    {
//        //foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<MoveWithMouse>>())
//        //{
//        //    var pos = Input.mousePosition;
//        //    pos.z -= Camera.main.transform.position.z;
//        //    transform.ValueRW.Position = Camera.main.ScreenToWorldPoint(pos);
//        //}
//    }
//}
