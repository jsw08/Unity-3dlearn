using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] CharacterController cc;
  [SerializeField] float speed = 1;
  private bool movingIsDown = false;
  private Vector2 movementDirection = Vector2.zero;

  void FixedUpdate()
  {
    /*Vector3 forward = transform.TransformDirection(transform.forward);*/
    /*float curSpeed = speed*/
    /*Debug.Log(finalMovement);*/
    Vector3 move = new Vector3(movementDirection.x, movementDirection.y);
    cc.SimpleMove(move * speed);
  }

  private void OnJump()
  {
    /*if (isGrounded)*/
    /*  rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);*/

  }

  private void OnMove(InputValue value)
  {
    movementDirection = value.Get<Vector2>();
  }
}
