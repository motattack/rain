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
    private bool looksRight = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueUI.IsOpen || PauseMenu.isPaused) return;
        
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
        looksRight = !looksRight;
        if (looksRight)
        {
            _animator.Play("walk");
        }
        else
        {
            _animator.Play("lwalk");
        }
    }

    private void SetTargetPosition()
    {
        _targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        var position = transform.position;
        _targetPos.y = position.y;
        _targetPos.z = position.z;
        
        _isMoving = true;
        
        

        if (_targetPos.x > transform.position.x && !looksRight) Flip();
        if (_targetPos.x < transform.position.x && looksRight) Flip();
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
