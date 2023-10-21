using DG.Tweening;
using Framework;
using Framework.Shake;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class RangedWeaponComponent : MonoBehaviour, IEntityComponent, IProcessable, IShotListener, IReloadingListener
    {
        // Serialized fields
        
        [SF] private int maxAmmo = 30;
        [SF] private float fireRate = 0.2f;
	
        [SF] private Transform shootingPoint;
        [SF] private Transform weaponHolder;
        [SF] private SpriteRenderer weaponRenderer;
        [SF] private SpriteRenderer muzzleFlash;
        [SF] private Sprite horiznotalSprite;
        [SF] private Sprite verticalSprite;
        
        [SF] private CameraShakeConfig shotShakeConfig;
        
        [SF] protected ParticleSystem bulletDropVFX;
        [SF] protected ParticleSystem shootVFX;
        
    	// Private fields
	    
	    private IEntityInputComponent inputComponent;
	    private IShakeHandler shakeHandler;

	    // Properties
	
    	//RangedWeaponComponent
	    
	    [Inject]
	    private void Construct(IShakeHandler shakeHandler)
	    {
		    this.shakeHandler = shakeHandler;
	    }
	    
	    public void Initialize(EntityView entityView)
	    {
		    var entity = entityView.Entity;
		    
		    entity.isWeapon = true;
		    entity.AddDirection(Vector3.zero);
		    entity.AddAmmo(maxAmmo);
		    entity.AddMaxAmmo(maxAmmo);
		    entity.AddFireRate(fireRate);
		    entity.AddShootingPoint(shootingPoint);
			
		    entity.AddShotListener(this);
		    entity.AddReloadingListener(this);
		    
		    inputComponent = GetComponentInParent<IEntityInputComponent>();
	    }

	    public void Process(in float deltaTime)
	    {
		    RotateWeapon(deltaTime);
		    RotateSprite();
	    }

	    private void RotateWeapon(in float deltaTime)
	    {
		    var aimingDirection = inputComponent.LookDirection;
			
		    float angle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
		    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			
		    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * deltaTime);
	    }
	    
	    private void RotateSprite()
	    {
		    var rotationAngle = transform.rotation.eulerAngles.z;
			
		    if ((rotationAngle >= 45 && rotationAngle <= 135) || (rotationAngle >= 225 && rotationAngle <= 315))
		    {
			    weaponRenderer.sprite = verticalSprite;

			    if ((rotationAngle >= 45 && rotationAngle <= 135))
			    {
				    transform.localPosition = new Vector3(0, 0.3f, 1.5f);
			    }
			    else
			    {
				    transform.localPosition = Vector3.up * 0.15f;
			    }
		    }
		    else
		    {
			    weaponRenderer.sprite = horiznotalSprite;
				
			    var faceRight = transform.rotation.eulerAngles.z < 90 || transform.rotation.eulerAngles.z > 270;
			    weaponHolder.transform.localScale = new Vector3(1, faceRight ? 1 : -1, 1);
				
			    transform.localPosition = Vector3.up * 0.15f;
		    }
	    }
        
	    public void OnShot(GameEntity entity)
	    {
		    muzzleFlash.DOKill(true);
			
		   //muzzleFlash.sprite = muzzleFlashes.RandomResult();
		   //muzzleFlash.DOFade(1f, 0.03f).OnComplete(() =>
		   //{
		//    muzzleFlash.DOFade(0f, 0f);
		   //});
            
		    weaponHolder.DOKill(true);
		    transform.DOKill(true);
		    var offset = Random.Range(0.05f, 0.15f);
		    transform.DOPunchPosition(-transform.right * offset, 0.1f);
			
		    shakeHandler.Shake(shotShakeConfig, 1f);
			
		    bulletDropVFX.Play();
		    shootVFX.Play();
	    }

	    public void OnReloading(GameEntity entity)
	    {
	    }
    }
}
