using ECS;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace ECS
{
	public class MovementSystem : JobComponentSystem
	{
		[BurstCompile]
		public struct MovementJob : IJobProcessComponentData<Position, Rotation, MoveSpeed>
		{
			public float topBound;
			public float bottomBound;
			public float deltaTime;

			public void Execute(ref Position position, [ReadOnly] ref Rotation rotation, [ReadOnly] ref MoveSpeed moveSpeed)
			{
				float3 value = position.value;
				value += deltaTime * moveSpeed.value * math.forward(rotation.value);

				if (value.z < bottomBound)
				{
					value.z = topBound;
				}

				position.value = value;
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			MovementJob moveJob = new MovementJob()
			{
				topBound = GameManager.instance.topBound,
				bottomBound = GameManager.instance.bottomBound,
				deltaTime = Time.deltaTime
			};

			JobHandle moveHandle = moveJob.Schedule(inputDeps);
			return moveHandle;
		}
	}
}

