using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float torqueAmount = 10f;
    [SerializeField] private float defaultSpeed = 15f;
    [SerializeField] private float boostedSpeed = 20f;
    [SerializeField] private float jumpForce = 50f;
    
    public LayerMask groundLayer;
    
    private bool _isGrounded;
    
    private Rigidbody2D _rigidbody;
    private SurfaceEffector2D _surfaceEffector2D;
    
    [ContextMenu("BuildPlayer")]
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    
    private void Update()
    {
        HandleBoost();
        HandleJump();
        HandleRotation();
    }

    private void HandleBoost()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _surfaceEffector2D.speed = boostedSpeed;
        }

        else
        {
            _surfaceEffector2D.speed = defaultSpeed;
        }
    }

    private void HandleJump()
    {
        _isGrounded = IsGrounded();
        
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody.AddTorque(torqueAmount);
        }
        
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody.AddTorque(-torqueAmount);
        }
    }
    
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 3f, groundLayer);
        return hit.collider != null;
    }
}