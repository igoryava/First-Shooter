using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _crouchYScale;
    [SerializeField] private float _defaultYScale;

    [SerializeField] private KeyCode _jumpKeyCode;
    [SerializeField] private KeyCode _sprintKeyCode;
    [SerializeField] private KeyCode _crouchKeyCode;


    private float _moveX;
    private float _moveZ;
    private float _defaultMovementSpeed;

    private bool _isGrounded;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _defaultYScale = transform.localScale.y;
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
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");

        _rigidbody.velocity = transform.rotation * new Vector3(_moveX * _defaultMovementSpeed, _rigidbody.velocity.y, _moveZ * _defaultMovementSpeed);
    }

    private void Sprint()
    {
        _defaultMovementSpeed = _sprintSpeed;
    }

    private void NormalizeMovementSpeed()
    {
        _defaultMovementSpeed = _walkSpeed;
    }

    private void NormalizeYScale()
    {
        transform.localScale = new Vector3(transform.localScale.x, _defaultYScale, transform.localScale.z);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void Crouch()
    {
        _defaultMovementSpeed = _crouchSpeed;
        transform.localScale = new Vector3(transform.localScale.x, _crouchYScale, transform.localScale.z);
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
