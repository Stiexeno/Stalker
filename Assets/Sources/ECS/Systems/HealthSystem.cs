using System.Collections.Generic;
using Entitas;

namespace Roguelite
{
    public class HealthSystem :  ReactiveSystem<GameEntity>
    {
	    private readonly Contexts contexts;

	    public HealthSystem(Contexts contexts) : base(contexts.game)
	    {
		    this.contexts = contexts;
	    }

	    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
		    context.CreateCollector(GameMatcher.DamageReceived.Added());

	    protected override bool Filter(GameEntity entity) => 
		    entity.hasTargetId;

	    protected override void Execute(List<GameEntity> entities)
	    {
		    foreach (var damageEntity in entities)
		    {
			   GameEntity targetEntity = contexts.game.GetEntityWithId(damageEntity.targetId.value);

			   if (targetEntity.hasHealth == false || targetEntity.isDead)
				   continue;
			   
			   targetEntity.ReplaceHealth(targetEntity.health.value - damageEntity.damageReceived.value);
			   targetEntity.isDead = targetEntity.health.value <= 0;
		    }
	    }
    }
}
