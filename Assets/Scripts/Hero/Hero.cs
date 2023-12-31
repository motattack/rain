using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero instance;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private DialogueUI _dialogueUI;
    [SerializeField] private GameObject _actionBar;

    public int balance = 2500;

    public DialogueUI DialogueUI => _dialogueUI;
    
    public IInteractable Interactable { get; set; }
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        instance = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        ToggleActionIndicator(false);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private bool IsGrounded()
    {
        return _groundCheck.IsTouchingLayer;
    }

    private void FixedUpdate()
    {
        if(_dialogueUI.IsOpen) return;
        
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);

        var isJumping = _direction.y > 0;
        if (isJumping)
        {
            if (IsGrounded() && _rigidbody2D.velocity.y <= 0)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
        }
        else if (_rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
        }
        
        _animator.SetBool("isWalking", _direction.x != 0);
        
        UpdateSpriteDirection();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
        }
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            _sprite.flipX = false;
        } else if (_direction.x < 0)
        {
            _sprite.flipX = true;
        }
    }

    public bool Purchase(int amount)
    {
        if (balance - amount >= 0)
        {
            balance -= amount;
            return true;
        }

        return false;
    }

    public void ToggleActionIndicator(bool status)
    {
        _actionBar.SetActive(status);
    }
    
    public bool IsAction()
    {
        return _actionBar.activeSelf;
    }

    public void SetBalance(int _balance)
    {
        balance = _balance;
    }
}