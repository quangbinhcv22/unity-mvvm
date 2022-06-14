using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private new Rigidbody rigidbody;

    [SerializeField] private float speed;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        var joystickDirection = joystick.Direction.normalized;
        var moveDirection = new Vector3(joystickDirection.x, default, joystickDirection.y) * speed;

        rigidbody.velocity = moveDirection;

        LookAt(moveDirection);
    }

    private void LookAt(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        _transform.DOLookAt(_transform.position + direction, 0.15f);
    }
}