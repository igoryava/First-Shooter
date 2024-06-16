using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Space(10)]
    [Header("Speed")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _crouchSpeed;

    [Space(10)]
    [Header("Jump")]
    [SerializeField] private float _jumpForce;

    [Space(10)]
    [Header("Crouch")]
    [SerializeField] private float _defaultHeight;
    [SerializeField] private float _crouchHeight;

    [SerializeField] private CapsuleCollider _collider;

    [Space(10)]
    [Header("Keycodes")]
    [SerializeField] private KeyCode _jumpKeyCode;
    [SerializeField] private KeyCode _sprintKeyCode;
    [SerializeField] private KeyCode _crouchKeyCode;


    private float _moveX;
    private float _moveZ;
    private float _currentMovementSpeed;

    private bool _isGrounded;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Walk();

        if (_isGrounded && Input.GetKeyDown(_jumpKeyCode))
        {
            Jump();
        }

        if(Input.GetKey(_sprintKeyCode))
        {
            Sprint();
        }
        else
        {
            NormalizeMovementSpeed();
        }

        if (Input.GetKey(_crouchKeyCode))
        {
            Crouch();
        }
        else
        {
            if(Input.GetKeyUp(_crouchKeyCode)) 
            {
                NormalizeYScale();
                NormalizeMovementSpeed();
            }
        }
    }

    private void Walk()
    {
        GetInputs();

        _rigidbody.velocity = transform.rotation * new Vector3(_moveX * _currentMovementSpeed, _rigidbody.velocity.y, _moveZ * _currentMovementSpeed);
    }

    private void GetInputs()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }

    private void Sprint()
    {
        _currentMovementSpeed = _sprintSpeed;
    }

    private void NormalizeMovementSpeed()
    {
        _currentMovementSpeed = _walkSpeed;
    }

    private void NormalizeYScale()
    {
        _collider.height = _defaultHeight;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void Crouch()
    {
        _currentMovementSpeed = _crouchSpeed; 
        _collider.height = _crouchHeight;
        _rigidbody.AddForce(Vector3.down / 20, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Ground>(out Ground _ground))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground _ground))
        {
            _isGrounded = false;
        }
    }
}
