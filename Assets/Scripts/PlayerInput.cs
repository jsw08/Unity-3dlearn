using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  [SerializeField] Rigidbody rb;
  [SerializeField] Camera cam;
  [SerializeField] float moveSpeed = 10;
  [SerializeField] float jumpSpeed = 5;
  [SerializeField] float sensitivity = 5;
  private Vector2 movement;
  private bool isGrounded = true;
  private bool movingIsDown = false;
  private float xRotation = 0f;

  void FixedUpdate()
  {
    PlayerMovement();
  }

  private void OnLook(InputValue inputValue)
  {
    CameraMovement(inputValue);
  }

  private void OnJump()
  {
    if (isGrounded)
      rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
  }

  private void OnMove(InputValue value)
  {
    movement = value.Get<Vector2>();
    movingIsDown = movement.sqrMagnitude > 0;
  }

  private void CameraMovement(InputValue inputValue)
  {
    Vector2 looking = inputValue.Get<Vector2>();
    float lookX = looking.x * sensitivity * Time.deltaTime;
    float lookY = looking.y * sensitivity * Time.deltaTime;

    xRotation -= lookY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    transform.Rotate(Vector3.up * lookX);
  }

  private void PlayerMovement()
  {
    if (movingIsDown)
    {
      Vector3 pressedMovement = new Vector3(movement.x, 0, movement.y) * moveSpeed;
      rb.MovePosition(transform.position);
    }
    else if (rb.linearVelocity.sqrMagnitude > 0)
    {
      rb.AddForce(-rb.linearVelocity.normalized * moveSpeed);
    }

    rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, moveSpeed);
  }

  private void OnColissionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
      isGrounded = true;
  }
}
