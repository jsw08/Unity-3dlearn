using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
  [SerializeField] Rigidbody rb;
  [SerializeField] Camera cam;
  [SerializeField] float sensitivity = 50;
  private float xRotation = 0f;

  private void OnLook(InputValue inputValue)
  {
    Vector2 looking = inputValue.Get<Vector2>();
    float lookX = looking.x * sensitivity * Time.deltaTime;
    float lookY = looking.y * sensitivity * Time.deltaTime;

    xRotation -= lookY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    transform.Rotate(Vector3.up * lookX);
  }
}
