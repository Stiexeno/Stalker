using Roguelite;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class EnemyComponent : MonoBehaviour, IEntityComponent
{
    // Serialized fields
	
	// Private fields
	
	// Properties
	
	//EnemyComponent
	
	public void Initialize(EntityView entityView)
	{
		var entity = entityView.Entity;
		entity.isEnemy = true;
	}
}
