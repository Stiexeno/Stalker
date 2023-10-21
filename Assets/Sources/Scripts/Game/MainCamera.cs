using Framework;
using Framework.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public class MainCamera : MonoBehaviour, ICamera
	{
		[SF] protected Transform target;
		[SF] private float smoothTime = 0.3f;
		[SF] private float aimingOffset = 0.3f;
		[SF] private Vector3 extraOffset;

		private Vector3 initialOffset;
		private Vector3 velocity = Vector3.zero;
        
		private PlayerInput playerInput;
		private InputAction aimingDirection;

		public Camera Camera { get; set; }

		[Inject]
		private void Construct(PlayerInput playerInput)
		{
			this.playerInput = playerInput;

			aimingDirection = playerInput.actions[Constants.Input.Actions.Aiming];
		}
		
		public void SetSmoothTime(float value)
		{
			smoothTime = value;
		}

		public void SetTarget(Transform target)
		{
			this.target = target;

			initialOffset = transform.position - target.position;
		}

		public void SetOffset(Vector3 offset)
		{
			extraOffset = offset;
		}

		protected virtual void Awake()
		{
			if (target != null)
				initialOffset = transform.position - target.position;
		}

		protected virtual void LateUpdate()
		{
			if (target != null)
			{
				var mousePosition = Camera.main.ScreenToWorldPoint(aimingDirection.ReadValue<Vector2>());
				var direction =  mousePosition.ToVector2() - new Vector2(target.transform.position.x, target.transform.position.y);
				var offset = direction * aimingOffset;
				offset = Vector3.ClampMagnitude(offset, 1.5f);

				extraOffset = new Vector3(offset.x, offset.y, 0);
				
				var targetPosition = target.position + initialOffset + extraOffset;
				transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
			}
		}
	}
}