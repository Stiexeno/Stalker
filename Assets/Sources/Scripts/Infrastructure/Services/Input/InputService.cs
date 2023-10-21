using Framework;
using UnityEngine;

namespace Roguelite
{
    public class InputService : IInputService, IProcessable
    {
        // Private fields
        
        private Vector2 axis;
        
        private const float SENSTIVITY = 100f;

        public Vector2 Movement => axis;
        public Vector2 MousePosition { get; private set; }
        
        public bool Mouse0Pressed { get; private set; }

        public void Process(in float deltaTime)
        {
            ProcessMovement();
            ProcessMouse();
            ProcessKeyboard();
        }

        private void ProcessMovement()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (Mathf.Approximately(horizontal, 0) == false || Mathf.Approximately(vertical, 0) == false)
            {
                var input = new Vector2(horizontal, vertical);
                
                if (input.sqrMagnitude > 1)
                {
                    input.Normalize();
                }
                
                axis = Vector2.Lerp(Movement, input, SENSTIVITY * Time.deltaTime);
            }
            else
            {
                axis = Vector2.Lerp(Movement,Vector2.zero,SENSTIVITY * Time.deltaTime);
                    
                if (Movement.sqrMagnitude < 0.01f) // consider it's zero already at this point
                {
                    axis = Vector2.zero;
                }
            }
            
        }

        private void ProcessMouse()
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                Mouse0Pressed = true;
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                Mouse0Pressed = false;
            }
        }

        private void ProcessKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
            }
        }
    }
}
