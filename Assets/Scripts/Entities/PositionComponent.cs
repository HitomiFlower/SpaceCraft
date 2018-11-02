using System;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS
{
    [Serializable]
    public struct Position : IComponentData
    {
        public float3 value;
    }
    public class PositionComponent : ComponentDataWrapper<Position>
    {
    }
}

