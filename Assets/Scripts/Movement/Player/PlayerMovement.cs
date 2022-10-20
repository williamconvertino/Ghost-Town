using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This design was heavily inspired by TaroDev, though redone for my own uses.
//https://github.com/Matthew-J-Spencer/Ultimate-2D-Controller
public class AltPlayerMovement : MonoBehaviour
{
    
    #region Core
    [Header("Interaction Masks")]
    [SerializeField] private LayerMask solidLayerMask;
    [SerializeField] private LayerMask headCollisionMask;
    
    private Rigidbody2D _rb2d;
    private BoxCollider2D _boxCollider;
    private PlayerInput _playerInput;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerInput = GetComponentInChildren<PlayerInput>();

        //Initializes detector boundaries.
        _boxCollider = GetComponent<BoxCollider2D>();
        Bounds colliderBounds = _boxCollider.bounds;
        _detectorLeft = colliderBounds.min.x;
        _detectorRight = colliderBounds.max.x;
        _detectorTop = colliderBounds.max.y;
        _detectorBottom = colliderBounds.min.y;
    }

    private void Update()
    {
        GetInput();
        Move();
    }
    
    #endregion

    #region Movement
    [Header("Movement")]
    [SerializeField] private float speedScale = 6.0f;
    [SerializeField] private float jumpScale = 25.0f;

    private Vector2 _velocity = Vector2.zero;
    public Vector2 GetVelocity => _velocity;

    public int DirectionX { private set; get; } = 0;
    
    //Always holds either -1 or 1, based on the most recent direction.
    public int MostRecentDirectionX { private set; get; } = 1;

    private PlayerInput.MovementInput _movementInput;
    
    //Moves the player according to physics and their input.
    private void Move()
    {
        UpdateDirection();
        
        _velocity.x = DirectionX * speedScale;

        UpdateGravity();
        CheckGrounding();
        UpdateJump();

        _rb2d.velocity = _velocity;
    }

    private void UpdateDirection()
    {
        if (_movementInput.DirX > 0)
        {
            DirectionX = MostRecentDirectionX = 1;
        }
        if (_movementInput.DirX < 0)
        {
            DirectionX = MostRecentDirectionX = -1;
        }
        if (_movementInput.DirX == 0)
        {
            DirectionX = 0;
        }
    }
    
    #endregion

    #region Gravity
    [Header("Gravity")]
    [SerializeField] private float minGravity = 80f;
    [SerializeField] private float maxGravity = 120f;
    [SerializeField] private float maxFallSpeed = 20f;
    [SerializeField] private float jumpApexThreshold = 10f;

    //Much of this logic is from TaroDev
    //https://github.com/Matthew-J-Spencer/Ultimate-2D-Controller
    private void UpdateGravity()
    {
        if (_headCollision && !_wasHeadCollision)
        {
            _velocity.y = 0;
        }

        float apexPoint = Mathf.InverseLerp(jumpApexThreshold, 0, Mathf.Abs(_velocity.y));
        float fallSpeed = Mathf.Lerp(minGravity, maxGravity, apexPoint);
        _velocity.y -= fallSpeed * Time.deltaTime;

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y = Mathf.Max(_velocity.y, -maxFallSpeed);
        }
    }

    #endregion

    #region Grounding
    [Header("Grounding")]
    
    [SerializeField] private int numGroundingDetectors = 3;
    [SerializeField] private float groundingDetectorLength = 0.02f;

    private bool _isGrounded;
    private bool _wasGrounded;
    private bool _headCollision;
    private bool _wasHeadCollision;
    
    private float _detectorLeft;
    private float _detectorRight;
    private float _detectorTop;
    private float _detectorBottom;


    private void CheckGrounding()
    {
        _wasGrounded = _isGrounded;
        _wasHeadCollision = _headCollision;

        _isGrounded = GetDetectorPositions(_detectorLeft, _detectorRight, _detectorBottom).Any(startingPoint => 
            Physics2D.Raycast(
                startingPoint, Vector2.down, groundingDetectorLength,  solidLayerMask
            ).collider != null
        );
        _headCollision = GetDetectorPositions(_detectorLeft, _detectorRight, _detectorTop).Any(startingPoint => 
            Physics2D.Raycast(
                startingPoint, Vector2.up, groundingDetectorLength,  headCollisionMask
            ).collider != null
        );
    }

    private IEnumerable<Vector2> GetDetectorPositions(float detectorStartX, float detectorEndX, float detectorY)
    {
        float deltaT = (float)1 / (numGroundingDetectors - 1);
        float t = 0.0f;
        
        for (int i = 0; i < numGroundingDetectors - 1; i++)
        {
            yield return new Vector2(Mathf.Lerp(detectorStartX, detectorEndX, t), detectorY);
            t += deltaT;
        }
        yield return new Vector2(detectorEndX, detectorY);
    }

    #endregion
    
    #region Jump
    [Header("Coyote Jump")]
    [SerializeField] private float coyoteJumpTime = 0.15f;
    
    private float _coyoteJumpCurrentTimer = 0.0f;

    private bool _canJump = false;
    
    private void UpdateJump()
    {
        if (!_wasGrounded && _isGrounded)
        {
            _canJump = true;
        }

        if (_isGrounded)
        {
            _coyoteJumpCurrentTimer = coyoteJumpTime;
        }
        else
        {
            _coyoteJumpCurrentTimer -= Time.deltaTime;
        }
        
        if (_canJump && _movementInput.DoJump && _coyoteJumpCurrentTimer >= 0 && _velocity.y <= 0)
        {
            _canJump = false;
            _velocity.y = jumpScale;
        }

    }
    #endregion
    
    #region Input
    
    //Gets the player's current input.
    private void GetInput()
    {
        _movementInput = _playerInput.GetMovementInput();
    }
    
    //A struct for storing the player's input.
    

    #endregion
    
    #region Gizmos
    private void OnDrawGizmos()
    {
        //Initializes components
        _boxCollider = GetComponent<BoxCollider2D>();
        Bounds bounds = _boxCollider.bounds;
        float detectorLeft = bounds.min.x;
        float detectorRight = bounds.max.x;
        float detectorTop = bounds.max.y;
        float detectorBottom = bounds.min.y;
        
        //Iterates through each detector point on the bottom and draws a ray down. 
        Gizmos.color = Color.blue;
        foreach (Vector2 startingPoint in GetDetectorPositions(detectorLeft, detectorRight, detectorBottom))
        {
            Gizmos.DrawRay(startingPoint, Vector2.down * groundingDetectorLength);    
        }
        
        //Iterates through each detector point on the top and draws a ray up.
        Gizmos.color = Color.yellow;
        foreach (Vector2 startingPoint in GetDetectorPositions(detectorLeft, detectorRight, detectorTop))
        {
            Gizmos.DrawRay(startingPoint, Vector2.up * groundingDetectorLength);    
        }
    }
    #endregion
}