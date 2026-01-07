using System.Runtime.CompilerServices;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;

    private Vector2 moveInput;

    private Vector3 verticalVelocity;

    public float moveSpeed = 5f;
    public float rotSpeed = 10f;
    public float jumpPower = 10f;
    public float gravity = -30f;

    public InputActionAsset inputAsset;

    private InputAction move;
    private InputAction attack;
    private InputAction jump;
    private InputAction interaction;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        move = inputAsset.actionMaps[0].actions[0];
        attack = inputAsset.actionMaps[0].actions[1];
        jump = inputAsset.actionMaps[0].actions[2];
        interaction = inputAsset.actionMaps[0].actions[3];

        //move = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        moveInput = move.ReadValue<Vector2>(); // 이동기 버튼 - 이동은 move.ReawdValue.
        
        Vector3 inputDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        Vector3 moveVector = Vector3.zero;

        if (inputDir.magnitude >= 0.1f)  // DeadZone 설정
        {
            moveVector = inputDir * moveSpeed;

            Quaternion targetRot = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }

        if (cc.isGrounded && verticalVelocity.y < 0f)
            verticalVelocity.y = -1f;

        if (attack.WasPressedThisFrame()) // 공격 버튼
        {
            Debug.Log("Attack");
        }

        if (jump.WasPressedThisFrame() && cc.isGrounded) // 점프 버튼
        {
            Debug.Log("Jump");
            verticalVelocity.y = jumpPower;
        }

        if (interaction.WasPressedThisFrame()) // 상호작용 버튼 한번 사용// interaction.IsPressed()를 사용하면 여러번 사용
        {
            Debug.Log("Interaction");
        }

        verticalVelocity.y += gravity * Time.deltaTime;

        Vector3 finalVector = (moveVector + verticalVelocity) * Time.deltaTime;
        cc.Move(finalVector);

    }





}
