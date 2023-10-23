using Framework;
using Roguelite;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class MeleeWeaponComponent : MonoBehaviour, IEntityComponent, IProcessable
{
    // Serialized fields
    
    [SF] private Transform weaponHolder;
    [SF] private Transform weaponRenderer;
    [SF] private AnimationCurve rotationCurve;
	
	// Private fields
	
	private IEntityInputComponent inputComponent;
	private bool facingRight = true;
	
	// Properties
	
	//MeleeWeaponComponent
	
	public void Initialize(EntityView entityView)
	{
		var entity = entityView.Entity;
		    
		entity.isWeapon = true;
		entity.AddDirection(Vector3.zero);
		
		inputComponent = GetComponentInParent<IEntityInputComponent>();
	}

	public void Process(in float deltaTime)
	{
		var aimingDirection = inputComponent.LookDirection;
			
		float angle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * deltaTime);
		
		var rotationAngle = transform.rotation.eulerAngles.z;
		var faceRight = transform.rotation.eulerAngles.z < 90 || transform.rotation.eulerAngles.z > 270;
		
		//var localPosition = weaponHolder.localPosition;
		//localPosition.x = faceRight ? 0.25f : -0.25f;
		//weaponHolder.localEulerAngles = new Vector3(0, 0, faceRight ? 90 : 270);
		Debug.LogError(rotationAngle);
		Debug.LogError(transform.right);

		//if (rotationAngle > 260f)
		//{
		//	var targetRotation = transform.rotation.eulerAngles.z < 90 || transform.rotation.eulerAngles.z > 260;
		//	weaponHolder.localEulerAngles = new Vector3(0, 0, faceRight ? 90 : 270);
		//}else if (rotationAngle < 100f)
		//{
		//	var targetRotation = transform.rotation.eulerAngles.z < 90 || transform.rotation.eulerAngles.z > 260;
		//	weaponHolder.localEulerAngles = new Vector3(0, 0, faceRight ? 90 : 270);
		//}

		if (facingRight)
		{
			if (transform.right.x <= -0.72f)
			{
				facingRight = false;
				weaponHolder.localEulerAngles = new Vector3(0, 0, 270);
			}
		}
		else
		{
			if (transform.right.x >= 0.72f)
			{
				facingRight = true;
				weaponHolder.localEulerAngles = new Vector3(0, 0, 90);
			}
		}

		var targetPosition = Mathf.Lerp(0, 1, rotationCurve.Evaluate(Mathf.Abs(transform.right.x)));
		weaponHolder.transform.localPosition = new Vector3(targetPosition, 0, 0);

		var weaponPosition = Mathf.Lerp(-4, 0, transform.right.y);
		weaponRenderer.transform.localPosition = new Vector3(weaponRenderer.transform.localPosition.x, weaponRenderer.transform.localPosition.y, weaponPosition);
	}
}
