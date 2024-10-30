using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    Vector2 curMovementInput;
    public float jumpPower;

    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    public Rigidbody rigidbody;

    public bool isOnMovingPlatform = false;
    public Transform movingPlatform;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.6f) + (transform.up * 0.01f) ,Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.6f) + (transform.up * 0.01f) ,Vector3.down),
            new Ray(transform.position + (transform.right * 0.6f) + (transform.up * 0.01f) ,Vector3.down),
            new Ray(transform.position + (-transform.right * 0.6f) + (transform.up * 0.01f) ,Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            Debug.DrawRay(rays[i].origin, Vector3.down, Color.red);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    void CameraLook()
    {
        //X축 = 상하 , 인풋(mouseDelta)에서 2d 벡터로 앞뒤는 y로 받음
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    void Move()
    {
        //마우스로 방향 전환 후에도 처음의 방향으로만 감
        //Vector3 direction = new Vector3(curMovementInput.x, rigidbody.velocity.y, curMovementInput.y);

        Vector3 direction = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;

        direction *= moveSpeed;

        direction.y = rigidbody.velocity.y;

        rigidbody.velocity = direction;

        if (isOnMovingPlatform)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, movingPlatform.position.z);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    //Ray[] rays = new Ray[4];

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.6f) + (transform.up * 0.01f) ,Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.6f) + (transform.up * 0.01f) ,Vector3.down),
            new Ray(transform.position + (transform.right * 0.6f) + (transform.up * 0.01f) ,Vector3.down),
            new Ray(transform.position + (-transform.right * 0.6f) + (transform.up * 0.01f) ,Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1f, groundLayerMask))
            {
                return true;

            }
        }
        return false;

    }
}
