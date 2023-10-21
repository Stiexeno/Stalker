using Framework;
using Roguelite;
using Roguelite.Bot;
using UnityEngine;
using UnityEngine.AI;
using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(ECSAgent), typeof(NavMeshAgent))]
public class AgentComponent : MonoBehaviour, IEntityComponent, IProcessable
{
    // Serialized fields
	
	// Private fields

	private ECSAgent ecsAgent;
	private NavMeshAgent agent;
	
	// Properties
	
	//AgentComponent
	
	public void Initialize(EntityView entityView)
	{
		agent = GetComponent<NavMeshAgent>();
		ecsAgent = GetComponent<ECSAgent>();
		
		ecsAgent.Setup(entityView.Entity, entityView.Context);
		agent.updateRotation = false;
		agent.updateUpAxis = false;
	}

	public void Process(in float deltaTime)
	{
		ecsAgent.Process();
	}
}