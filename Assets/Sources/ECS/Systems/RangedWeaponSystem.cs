using Entitas;
using Framework.Core;
using Framework.Utils;
using Roguelite;
using UnityEngine;

public class RangedWeaponSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private IGroup<GameEntity> weaponEntities;
	private IGroup<GameEntity> pooledProjectiles;
	private IWeaponFactory weaponFactory;

	public RangedWeaponSystem(Contexts contexts, IWeaponFactory weaponFactory)
	{
		this.weaponFactory = weaponFactory;
		this.contexts = contexts;

		weaponEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.Weapon, GameMatcher.RangedWeapon)
			.NoneOf(GameMatcher.ShootingCooldown, GameMatcher.Reloading));

		pooledProjectiles = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.Projectile, GameMatcher.SentToPool));
	}

	public void Execute()
	{
		ProcessShooting();
	}

	private void ProcessShooting()
	{
		foreach (var weaponEntity in weaponEntities.GetEntities())
		{
			var weaponOwner = contexts.game.GetEntityWithId(weaponEntity.ownerId.value);
			
			if (CanShoot(weaponEntity, weaponOwner))
			{
				Shoot(weaponEntity, weaponOwner);
			}
		}
	}

	private void Shoot(GameEntity weaponEntity, GameEntity weaponOwner)
	{
		weaponOwner.isAttacking = true;
		
		var direction = weaponEntity.direction.value;
		var bullet = GetBullet();
		bullet.Entity.transform.value.position = weaponEntity.shootingPoint.value.position.ToVector2() + direction * 0.5f;

		var spread = Random.Range(-1.5f, 1.5f);
		var spreadDirection = Quaternion.AngleAxis(spread, Vector3.forward) * direction;
		
		bullet.Entity.ReplaceDirection(spreadDirection);
		bullet.Reuse();
        
		weaponEntity.isShot = true;
		weaponOwner.isShot = true;
		
		weaponEntity.ammo.value--;

		if (weaponEntity.ammo.value <= 0)
		{
			weaponOwner.ReloadWeapon(contexts.game);
			return;
		}

		weaponEntity.isShootingCooldown = true;
		AddShootingCooldown(weaponEntity);
	}

	private void AddShootingCooldown(GameEntity weaponEntity)
	{
		contexts.game.CreateEntity()
			.AddCooldown(weaponEntity, weaponEntity.fireRate.value)
			.With(x => x.isShootingCooldown = true);
	}
	
	private EntityView GetBullet()
	{
		EntityView bullet = null;
		
		foreach (var pooledProjectile in pooledProjectiles.GetEntities())
		{
			bullet = pooledProjectile.entityBehaviour.value;
		}

		if (bullet != null)
		{
			bullet.Entity.isSentToPool = false;
		}
		else
		{
			bullet = weaponFactory.CreateBullet();
		}
		
		bullet.Entity.ReplaceLifetime(2f);
		
		return bullet;
	}

	private bool CanShoot(GameEntity weaponEntity, GameEntity weaponOwner)
	{
		return weaponOwner.isAttacking;
	}
}