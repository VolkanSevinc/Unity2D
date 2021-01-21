using UnityEngine;

public class FoxScript : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float moveSpeed;
    public Animator animator;

    private int count = 0;
    public float lastRandomX;
    public float lastRandomY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 200)
        {
            lastRandomX = -lastRandomX;
            lastRandomY = -lastRandomY;

            count = 0;
        }

        var velocity = new Vector2(lastRandomX, lastRandomY) * moveSpeed;
        rigidBody2D.velocity = velocity;

        animator.SetFloat("moveX", velocity.x);
        animator.SetFloat("moveY", velocity.y);

        if (lastRandomX == 1 || lastRandomX == -1 || lastRandomY == 1 || lastRandomY == -1)
        {
            animator.SetFloat("lastMoveX", lastRandomX);
            animator.SetFloat("lastMoveY", lastRandomY);
        }


        transform.position = new Vector3(transform.position.x,
            transform.position.y, transform.position.z);

        count++;
    }
}