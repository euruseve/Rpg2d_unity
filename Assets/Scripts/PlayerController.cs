using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public string AreaTransitionName { get; set; }
    public bool CanMove { get; set; }

    [SerializeField] private float moveSpeed = 10;

    private Rigidbody2D _rb; 
    private Animator _animator;
    private Vector3 _bottomLeftLimit, _topRightLimit; 

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        CanMove = true;

        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(CanMove)
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x),
                                        Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y),
                                        transform.position.z);

        Animate();
    }

    private void Animate()
    {
        _animator.SetFloat("moveX", _rb.velocity.x);
        _animator.SetFloat("moveY", _rb.velocity.y);

        if (CanMove)
        {
            if (Input.GetAxisRaw("Horizontal") == 1 || 
            Input.GetAxisRaw("Horizontal") == -1 || 
            Input.GetAxisRaw("Vertical") == 1 || 
            Input.GetAxisRaw("Vertical") == -1)
            {
                _animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                _animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        _bottomLeftLimit = botLeft + new Vector3(.4f, .4f, 0);
        _topRightLimit = topRight + new Vector3(-.4f, -.4f, 0);;
    }
}
