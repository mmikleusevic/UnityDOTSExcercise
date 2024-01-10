using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerShootingSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);
        }

        if (!Input.GetKeyDown(KeyCode.Space)) return;

        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);

        foreach (RefRO<LocalTransform> localTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>().WithDisabled<Stunned>())
        {           
            Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnCubesConfig.cubePrefabEntity);

            entityCommandBuffer.SetComponent(spawnedEntity, new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Scale = 1,
                Rotation = quaternion.identity
            });
        }

        entityCommandBuffer.Playback(EntityManager);
    }
}
