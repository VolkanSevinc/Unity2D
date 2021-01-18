using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float moveSpeed;
    public Animator animator;

    public static PlayerController instance;

    public string areaTransitionName;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            var horizontalAxisRaw = Input.GetAxisRaw("Horizontal");
            var verticalAxisRaw = Input.GetAxisRaw("Vertical");

            var velocity = new Vector2(horizontalAxisRaw, verticalAxisRaw) * moveSpeed;
            rigidBody2D.velocity = velocity;

            animator.SetFloat("moveX", velocity.x);
            animator.SetFloat("moveY", velocity.y);

            if (horizontalAxisRaw == 1 || horizontalAxisRaw == -1 || verticalAxisRaw == 1 || verticalAxisRaw == -1)
            {
                animator.SetFloat("lastMoveX", horizontalAxisRaw);
                animator.SetFloat("lastMoveY", verticalAxisRaw);
            }


            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x),
                Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), transform.position.z);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(0, 0);
        }
    }

    public void setTileBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        var vector3 = new Vector3(0.5f, 0.5f, 0);

        this.bottomLeft = bottomLeft + vector3;
        this.topRight = topRight - vector3;
    }
}