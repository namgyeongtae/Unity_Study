using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    private Vector3 moveInput;
    private Vector3 moveVector;
    private Vector3 verticalVelocity;

    private float currentSpeed;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float rotSpeed = 10f;
    
    [SerializeField] private float gravity = -30f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Turn();
        SetAnimation();
    }

    void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<ITriggerEvent>();

        if (interactable != null)
        {
            interactable.InteractEnter();
        }
    }

    void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<ITriggerEvent>();

        if (interactable != null)
        {
            interactable.InteractExit();
        }
    }

    private void Move()
    {
        if (moveInput.magnitude >= 0.1f) // 움직일 때
        {
            currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            if (cc.isGrounded && verticalVelocity.y < 0)
            verticalVelocity.y = -1f;

            verticalVelocity.y += gravity * Time.deltaTime;

            moveVector = moveInput.normalized * currentSpeed;

            Vector3 finalMovement = (moveVector + verticalVelocity) * Time.deltaTime;
            cc.Move(finalMovement); // 이동 기능능
        }
        else // 안 움직일 때
        {
            currentSpeed = 0f;
            cc.Move(verticalVelocity * Time.deltaTime);
        }
    }

    private void Turn()
    {
        if (moveInput.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }
    }

    private void SetAnimation()
    {
        // 아무런 키도 누르지 않으면 속도가 0 -> Idle
        // WASD 키를 누르면 속도 3 -> Walk
        // SHIFT + WASD 키를 누르면 속도 6 -> Run

        // anim.SetFloat("Speed", currentSpeed); // 즉시 변경
        anim.SetFloat("Speed", currentSpeed, 0.1f, Time.deltaTime); // 천천히 변경
    }

    private void OnMove(InputValue value)   // New Input System에서 데이터를 가져오는 기능
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveInput = new Vector3(inputDir.x, 0f, inputDir.y);
    }
}
