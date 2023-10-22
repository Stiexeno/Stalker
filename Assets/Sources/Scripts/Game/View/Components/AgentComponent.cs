using Framework;
using Framework.Bot.ECS;
using Roguelite;
using UnityEngine;
using UnityEngine.AI;
using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(ECSAgent), typeof(NavMeshAgent))]
public class AgentComponent : MonoBehaviour, IEntityInputComponent, IProcessable, IDeadListener
{
    // Serialized fields
	
	// Private fields

	private ECSAgent ecsAgent;
	private NavMeshAgent agent;
	private GameEntity entity;

	// Properties
	
	public Vector2 LookDirection { get; set;}
	public Vector2 Velocity { get; set;}
	
	//AgentComponent
	
	public void Initialize(EntityView entityView)
	{
		agent = GetComponent<NavMeshAgent>();
		ecsAgent = GetComponent<ECSAgent>();
		
		entity = entityView.Entity;
		entity.AddAgent(agent);
		
		ecsAgent.Setup(entityView.Entity, entityView.Context);
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		
		entity.AddDeadListener(this);
	}

	public void Process(in float deltaTime)
	{
		ecsAgent.Process();
		
		LookDirection = entity.direction.value;
		Velocity = entity.direction.value;
	}

	public void OnDead(GameEntity entity)
	{
		agent.enabled = false;
		this.entity.direction.value = Vector2.zero;
		ecsAgent.Disable();
	}
}
