using Entitas;
using Framework.Generated;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class InputSystem : IExecuteSystem
    {
	    private readonly Contexts contexts;
	    private IProjectileFactory projectileFactory;

	    public InputSystem(Contexts contexts)
	    {
		    //this.projectileFactory = projectileFactory;
		    this.contexts = contexts;
	    }
	    
	    public void Execute()
	    {
		    ProcessAttack();
		    ProcessMovement();
		    ProcessWeapon();
	    }

	    private void ProcessWeapon()
	    {
		    //var entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Input, GameMatcher.Weapon));
            //
		    //foreach (var entity in entities.GetEntities())
		    //{
			//    // Get the mouse position in world coordinates
			//    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//
			//    // Calculate the direction vector from the object to the mouse
			//    Vector3 direction = mousePosition - entity.weapon.owner.position.value;
			//    entity.weapon.direction = direction.normalized;
		    //}
	    }

	    private void ProcessAttack()
	    {
		   // var entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Input, GameMatcher.Weapon));
//
		   // if (Input.GetMouseButtonDown(0))
		   // {
		//	    foreach (var entity in entities.GetEntities())
		//	    {
		//		    var direction = entity.weapon.direction;
           //         
		//		    var rotation = Quaternion.LookRotation(direction, Vector3.forward);
		//		    var rotationToDirection = rotation * Vector3.forward;
		//		    
		//		    projectileFactory.Create(
		//			    Assets.Projectile, 
		//			    entity.weapon.owner.position.value,
		//			    new Vector2(rotationToDirection.x, rotationToDirection.y), 
		//			    50);
           //         
		//		    entity.isShot = true;
		//	    }
		   // }
	    }

	    private void ProcessMovement()
	    {
		   //var inputEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Input, GameMatcher.Movement));
		   //
		   //float horizontal = Input.GetAxisRaw("Horizontal");
		   //float vertical = Input.GetAxisRaw("Vertical");
		   //
		   //foreach (var inputEntity in inputEntities.GetEntities())
		   //{
		//    var axis = new Vector3(horizontal, vertical, 0);

		//    if (axis.sqrMagnitude > 1)
		//    {
		//	    axis.Normalize();
		//    }

		//    var targetVelocity = Vector2.Lerp(inputEntity.input.axis, axis, 15 * Time.deltaTime);
		//    
		//    inputEntity.ReplaceInput(targetVelocity);
		//    inputEntity.ReplaceMovement(targetVelocity , inputEntity.movement.speed);
		   //}
	    }
    }
}
