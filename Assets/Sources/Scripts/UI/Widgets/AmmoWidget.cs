using Entitas;
using Framework;
using Framework.Core;
using TMPro;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class AmmoWidget : Widget, IEventListener, IShotListener, IReloadingListener, IReloadedListener, IWeaponAddedListener
    {
        // Serialized fields
        
        [SF] private TMP_Text ammoText;
	
    	// Private fields

	    private GameEntity entity;
	    private IPlayer player;

	    // Properties
	
    	//AmmoWidget

	    [Inject]
	    private void Construct(IPlayer player)
	    {
		    this.player = player;
		    player.OnPlayerCreated += OnPlayerCreated;
	    }

	    private void OnPlayerCreated(EntityView player)
	    {
		    this.entity = player.Entity;
		    RegisterListeners(this.entity);
	    }

	    public void RegisterListeners(IEntity entity)
	    {
		    this.entity.AddShotListener(this);
		    this.entity.AddReloadingListener(this);
		    this.entity.AddReloadedListener(this);
		    this.entity.AddWeaponAddedListener(this);
	    }

	    public void UnregisterListeners(IEntity entity)
	    {
		    this.entity.RemoveShotListener(this);
		    this.entity.RemoveReloadingListener(this);
		    this.entity.RemoveReloadedListener(this);
		    this.entity.RemoveWeaponAddedListener(this);
	    }
	    
	    public void OnWeaponAdded(GameEntity entity)
	    {
		    UpateView();
	    }

	    public void OnShot(GameEntity entity)
	    {
		    UpateView();
	    }

	    public void OnReloading(GameEntity entity)
	    {
		   // ammoText.text = "Reloading...";
	    }

	    public void OnReloaded(GameEntity entity)
	    {
		    UpateView();
	    }
	    
	    private void UpateView()
	    {
		    var weapon = entity.currentWeapon.value;
		    if (weapon.ammo.value <= 0)
		    {
			    ammoText.text = "Reloading";
			    return;
		    }
		    
		    ammoText.text = $"{weapon.ammo.value}/{weapon.maxAmmo.value}";
	    }
    }
}
