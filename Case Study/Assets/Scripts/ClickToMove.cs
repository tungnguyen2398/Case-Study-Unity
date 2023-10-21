using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ClickToMove : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClickAction;
    [SerializeField]
    public float normalSpeed = 10f;
    public float colliedSpeed = 2f;
    [SerializeField]
    private float rotationSpeed = 5f;
    private Camera mainCamera;
    private Coroutine coroutine;

    private CharacterController characterController;
    private void Awake()
    {
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        mouseClickAction.Enable();
        mouseClickAction.performed += Move;
    }

    private void OnDisable()
    {
        mouseClickAction.performed -= Move;
        mouseClickAction.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
       Ray ray =  mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(PlayerMoveTowards(hit.point));
        }
    }

    private IEnumerator PlayerMoveTowards(Vector3 target)
    {
        float playerDistanceToFloor = transform.position.y - target.y;
        target.y += playerDistanceToFloor;
        while(Vector3.Distance(transform.position, target) > 0.1f)
        {
            Vector3 destination = Vector3.MoveTowards(transform.position, target, normalSpeed * Time.deltaTime);
            //transform.position = destination;

            Vector3 direction = target - transform.position;
            direction.y = 0;
            Vector3 movement = direction.normalized * normalSpeed * Time.deltaTime;
            characterController.Move(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
