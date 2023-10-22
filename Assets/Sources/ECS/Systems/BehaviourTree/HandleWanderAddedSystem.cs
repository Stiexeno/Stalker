using System.Collections.Generic;
using Entitas;
using Roguelite;
using UnityEngine;
using UnityEngine.AI;
using SF = UnityEngine.SerializeField;

public class HandleWanderAddedSystem : ReactiveSystem<GameEntity>
{
        private readonly IGroup<GameEntity> group;
        private readonly IGroup<GameEntity> agentGroup;
        private readonly GameContext contextGame;

        public HandleWanderAddedSystem(Contexts contexts) : base(contexts.game)
        {
            contextGame = contexts.game;

            agentGroup = contextGame.GetGroup(GameMatcher
                .AllOf(GameMatcher.Agent, GameMatcher.Id));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
            context.CreateCollector(GameMatcher.Wander.Added());

        protected override bool Filter(GameEntity entity) => 
            entity.hasOwnerId;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity nodeEntity in entities)
            {
                GameEntity ownerEntity = agentGroup.GetEntity(contextGame, nodeEntity.ownerId.value);
                
                if (ownerEntity == null)
                    continue;
                
                NavMeshAgent agent = ownerEntity.agent.value;
                agent.isStopped = false;
                
                Vector3 targetPoint = GetRandomPointOnNavMesh(agent);
                
                agent.SetDestination(GetFormattedDestination(targetPoint));

                nodeEntity.ReplaceTargetPosition(targetPoint);
                nodeEntity.ReplaceTimelapsed(0);
            }
        }
        
        Vector3 GetFormattedDestination(Vector3 targetPosition)
        {
            var agentDrift = 0.0001f;
            Vector2 driftPos = (Vector2)targetPosition + agentDrift * Random.insideUnitCircle;

            return driftPos;
        }
        
        private Vector3 GetRandomPointOnNavMesh(NavMeshAgent agent)
        {
            const float maxDistance = 5;
            
            Vector3 randomDirection = Random.insideUnitCircle.normalized * Random.Range(0f, maxDistance);
            Vector3 randomPosition = agent.transform.position + randomDirection;

            if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, maxDistance, NavMesh.AllAreas))
                return hit.position;

            return agent.transform.position;
        }
}
