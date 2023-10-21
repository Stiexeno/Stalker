using Entitas;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class ReloadingWidget : MonoBehaviour, IEventListener, IReloadingListener
    {
        // Serialized fields
        
        [SF] private RectTransform reloadBar;
	
    	// Private fields
	
	    private GameEntity entity;

	    private bool isActive;
	    private float reloadTime;
	    
    	// Properties
	
    	//ReloadingWidget
	    
	    public void RegisterListeners(IEntity entity)
	    {
		    this.entity = (GameEntity)entity;
		    this.entity.AddReloadingListener(this);
	    }

	    public void UnregisterListeners(IEntity entity)
	    {
		    this.entity.AddReloadingListener(this);
	    }

	    public void OnReloading(GameEntity entity)
	    {
		    var reloadingEntity = entity.currentWeapon.value.reloadingEntity.value;
		    reloadTime = reloadingEntity.durationLeft.value;
		    gameObject.SetActive(true);
		    isActive = true;
	    }

	    private void Update()
	    {
		    if (isActive)
		    {
			    var weapon = entity.currentWeapon.value;
			    var reloadingEntity = weapon.reloadingEntity.value;
			    var reloading = 1 - (reloadingEntity.durationLeft.value / reloadTime);

			    var positionX = Mathf.Clamp01(reloading) * 0.6f;
			    reloadBar.anchoredPosition = new Vector2(positionX, reloadBar.anchoredPosition.y);

			    if (reloading >= 1)
			    {
				    isActive = false;
				    gameObject.SetActive(false);
			    }
		    }
	    }
    }
}
