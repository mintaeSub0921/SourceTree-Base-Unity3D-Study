using UnityEngine;

public class StudyCC : MonoBehaviour
{
    private CharacterController cc;

    private Vector3 verticalVelocity;

    private float moveSpeed = 5f;
    private float rotSpeed = 10f;

    public float gravity = -30f;
    public float jumpPower = 10f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v).normalized;
        Vector3 moveVector = Vector3.zero;

        if (inputDir.magnitude >= 0.1f)  // DeadZone º≥¡§
        { 
            moveVector = inputDir * moveSpeed;

            Quaternion targetRot = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }

        Jump();

        Vector3 finalVector = (moveVector + verticalVelocity) * Time.deltaTime;
        //cc.Move(finalVector);

        CollisionFlags flags = cc.Move(finalVector);

        if ((flags & CollisionFlags.Below) != 0)
            Debug.Log("πﬂø° ¥Í¿Ω");

        if ((flags & CollisionFlags.Above) != 0)
            Debug.Log("∏”∏Æø° ¥Í¿Ω");

        if ((flags & CollisionFlags.Sides) != 0)
            Debug.Log("ø∑ø° ¥Í¿Ω");


    }

    private void Jump()
    {
        if (cc.isGrounded && verticalVelocity.y < 0f)
            verticalVelocity.y = -1f;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
            verticalVelocity.y = jumpPower;

        verticalVelocity.y += gravity * Time.deltaTime;
    }

}
