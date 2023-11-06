using Unity.Entities;
using Unity.Entities.Serialization;
using UnityEngine;

public class BasketAuthoring : MonoBehaviour
{
    public int numBaskets;
    public float basketBottomY;
    public float basketSpacingY;
    public GameObject basketPrefab;

    private class BasketBaker : Baker<BasketAuthoring>
    {
        public override void Bake(BasketAuthoring authoring)
        {
            var entityPrefab = GetEntity(authoring.basketPrefab, TransformUsageFlags.Dynamic);
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            var propertiesComponent = new BasketProperties
            {
                numBaskets = 3,
                basketBottomY = -14f,
                basketSpacingY = 2f
                basketEntity;
            };
            AddComponent(entity, propertiesComponent);
        }
    }
}

public struct BasketProperties : IComponentData
{
    public int numBaskets;
    public float basketBottomY;
    public float basketSpacingY;
    public EntityPrefabReference basketEntity;
}
