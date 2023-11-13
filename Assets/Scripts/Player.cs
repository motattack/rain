using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private GameObject actionButton;
    
    
    private bool _isMoving = false;
    private Vector3 _targetPos;
    public float speed = 3f;

    public DialogueUI DialogueUI => dialogueUI;
    
    public IInteractable Interactable { get; set; }

    
    private Animator _animator;
    private bool _looksRight = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if(dialogueUI.IsOpen || PauseMenu.IsPaused) return;
        
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (_isMoving)
        {
            Move();
        }
        
        DrawActionButton();
    }

    private void DrawActionButton()
    {
        
        if (Interactable != null)
        {
            actionButton.SetActive(true);
        }
        else
        {
            actionButton.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
            actionButton.SetActive(false);
        }
    }

    private void Flip()
    {
        _looksRight = !_looksRight;

    }

    private void SetTargetPosition()
    {
        _targetPos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        
        var position = transform.position;
        _targetPos.y = position.y;
        _targetPos.z = position.z;
        
        _isMoving = true;
        
        if (_looksRight)
        {
            _animator.Play("walk");
        }
        else
        {
            _animator.Play("lwalk");
        }
        

        if (_targetPos.x > transform.position.x && !_looksRight) Flip();
        if (_targetPos.x < transform.position.x && _looksRight) Flip();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
        if (transform.position == _targetPos)
        {
            _isMoving = false;
            _animator.Play("stay");
        }
    }
}
