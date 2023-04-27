using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Animator playerAnimator;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (isFacingRight == false && movement.x > 0)
        {
            FlipPlayer();
        }
        else if (isFacingRight == true && movement.x < 0)
        {
            FlipPlayer();
        }

        if (movement.x != 0 || movement.y != 0)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        Vector3 Scale = transform.localScale;
        Scale.x *= -1;

        transform.localScale = Scale;
    }

    public void IncreaseMovementSpeed(float value)
    {
        speed += value;
    }
}
