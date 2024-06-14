using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private KeyCode _jump;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _jumpLayer;
    [SerializeField] private Transform _groundChecker;

    private Vector3 _velocity;
    private bool _isGrounded;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Walk();
        if (_isGrounded && Input.GetKeyDown(_jump))
        {
            Jump();
        }
        GroundChecker();
    }

    private void Walk()
    {
        Vector3 direction = transform.rotation * new Vector3(Input.GetAxisRaw("Horizontal") * _walkSpeed * Time.deltaTime, _gravity, Input.GetAxisRaw("Vertical") * _walkSpeed * Time.deltaTime);

        _characterController.Move(direction);
    }


    private void Jump()
    {
        _velocity.y += _jumpForce * _gravity * Time.deltaTime;
    }

    private void GroundChecker()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _checkRadius, _jumpLayer);
    }
}
