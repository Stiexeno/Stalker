using Roguelite;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class HealthComponent : MonoBehaviour, IEntityComponent
{
    // Serialized fields
    
    [SF] private int maxHealth;
	
	// Private fields
	
	// Properties
	
	//HealthComponent
	
	public void Initialize(EntityView entityView)
	{
		var entity = entityView.Entity;
		entity.AddHealth(maxHealth);
		entity.AddMaxHealth(maxHealth);
	}
}
