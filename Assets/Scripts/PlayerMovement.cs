using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  private Rigidbody rb;

  [SerializeField]
  private float speed = 2f;

  [SerializeField]
  private float jumpHeight = 5f;
  private Vector2 moveInput;
  private bool isGrounded = true;

  void FixedUpdate()
  {
    Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y; // Transform.right is zegmaar rotation van gameobject naar vector geconvert zodat je het keer iets kan doen en hetzelfde met forward.
    rb.AddForce(move.normalized * speed, ForceMode.VelocityChange);
  }

  private void OnMove(InputValue value)
  {
    moveInput = value.Get<Vector2>();
  }

  private void OnJump()
  {
    if (!isGrounded) return;

    rb.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
    isGrounded = false;
  }
  private void OnCollisionEnter(Collision collission)
  {
    if (collission.gameObject.CompareTag("Ground")) isGrounded = true;
  }
}
