using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
  void Start()
  {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }
}
