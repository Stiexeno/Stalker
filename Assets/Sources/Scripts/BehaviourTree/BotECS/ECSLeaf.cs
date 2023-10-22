using Framework.Bot;

namespace Framework.Bot.ECS
{
	public abstract class ECSLeaf : BTLeaf, IECSNode
	{
		// Private fields
		
		protected GameEntity nodeEntity;
		protected GameEntity ownerEntity;
		protected GameContext gameContext;

		protected ECSParams ecsParams;

		// Properties

		//ECSLeaf

		public void Initialize(ECSParams ecsParams)
		{
			this.ecsParams = ecsParams;

			ownerEntity = ecsParams.entity;
			gameContext = ecsParams.contexts.game;

			nodeEntity = gameContext.CreateEntity();

			nodeEntity.AddOwnerId(ownerEntity.id.value);

			OnInit();
		}

		protected virtual void OnInit()
		{
		}


		/// <summary>
		/// Called by Framework. Don't call it manually.
		/// </summary>
		protected sealed override void OnEnter()
		{
			nodeEntity.ReplaceNodeStatus(BTStatus.Running);

			Enter();
		}

		/// <summary>
		/// Called by Framework. Don't call it manually.
		/// </summary>
		/// <returns>Node status</returns>
		protected sealed override BTStatus OnUpdate()
		{
			GameEntity entity = nodeEntity;

			if (!entity.hasNodeStatus)
				return BTStatus.Running;

			BTStatus updateResultStatus = nodeEntity.nodeStatus.value;

			if (updateResultStatus == BTStatus.Success)
			{
				OnSuccess();
				nodeEntity.ReplaceNodeStatus(BTStatus.Inactive);
			}
			else if (updateResultStatus == BTStatus.Failure)
			{
				OnFailure();
				nodeEntity.ReplaceNodeStatus(BTStatus.Inactive);
			}

			return updateResultStatus;
		}


		protected virtual void Enter()
		{
		}

		protected virtual void OnSuccess()
		{
		}

		protected virtual void OnFailure()
		{
		}
	}
}