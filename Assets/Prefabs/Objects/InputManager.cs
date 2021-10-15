
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;
    public Camera cameraMain;
    public GameObject objectToTest;
    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {

        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Vector3 screenCoordinates = new Vector3(touchPosition.x, touchPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = -10;
        //Fire 
        Ray ray = new Ray(worldCoordinates, Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            var interactableObj = hit.transform.gameObject.GetComponent<IInteractable>();
            if (interactableObj == null) return;
            interactableObj.Interact();

        }
        //objectToTest.transform.position = worldCoordinates;
        
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
    }
}
