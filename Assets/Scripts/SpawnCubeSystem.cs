using System.Numerics;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class SpawnCubeSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubesConfig>();
    }

    protected override void OnUpdate()
    {
        this.Enabled = false;

        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        NativeArray<Entity> entities = EntityManager.Instantiate(spawnCubesConfig.cubePrefabEntity, spawnCubesConfig.amountToSpawn, Allocator.Persistent);

        foreach(Entity entity in entities)
        {
            float x = UnityEngine.Random.Range(-10f, +5f);
            float y = 0.6f;
            float z = UnityEngine.Random.Range(-4f, +7f);

            SystemAPI.SetComponent(entity, new LocalTransform
            {
                Position = new float3(x, y, z),
                Scale = 1,
                Rotation = quaternion.identity
            });
        }
    }
}
