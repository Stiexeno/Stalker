using Framework.Bot;
using Framework.Bot.ECS;
using UnityEngine;
using UnityEngine.AI;

namespace Roguelite
{
    public class Wander : ECSLeaf
    {
        // Serialized fields
	
    	// Private fields
	    
	    private Vector2 targetPoint;
	    private float timelapsed;
	
    	// Properties
	
    	//Wander

	    protected override void Enter()
	    {
		    if (ecsParams.entity != null && ecsParams.entity.hasAgent)
		    {
			    var agent = ecsParams.entity.agent;
			    
			    agent.value.isStopped = false;
			    
			    targetPoint = GetRandomPointOnNavMesh(agent.value);
			    
			    agent.value.SetDestination(GetFormattedDestination(targetPoint));
			    timelapsed = 0;
		    }
	    }

	    protected override BTStatus Update()
	    {
		    var entity = ecsParams.entity;

		    if (ecsParams.entity != null && ecsParams.entity.hasAgent)
		    {
			    timelapsed += Time.deltaTime;
			    
			    if (Vector2.Distance(entity.transform.value.position, targetPoint) < 1 || timelapsed > 10)
			    {
				    entity.agent.value.isStopped = true;
				    return BTStatus.Success;
			    }

			    return BTStatus.Running;
		    }
		    
		    return BTStatus.Failure;
	    }
	    
	    Vector3 GetFormattedDestination(Vector3 targetPosition)
	    {
		    var agentDrift = 0.0001f;
		    Vector2 driftPos = (Vector2)targetPosition + agentDrift * Random.insideUnitCircle;

		    return driftPos;
	    }
	    
	    private Vector3 GetRandomPointOnNavMesh(NavMeshAgent agent)
	    {
		    float maxDistance = 5;
            
		    Vector3 randomDirection = Random.insideUnitCircle.normalized * Random.Range(0f, maxDistance);
		    Vector3 randomPosition = agent.transform.position + randomDirection;

		    if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, maxDistance, NavMesh.AllAreas))
		    {
			    return hit.position;
		    }

		    return agent.transform.position;
	    }
    }
}
