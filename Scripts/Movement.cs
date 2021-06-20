using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speed = 10;
    private readonly float speedModifier = 45f;
    private Rigidbody rb;
    private Vector3 newPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (GameManager.startGame)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        newPosition = Vector3.right * (touch.deltaPosition.x * speedModifier * Time.deltaTime);
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Stationary:
                        newPosition.x = 0;
                        break;
                }
                rb.velocity = Vector3.ClampMagnitude(new Vector3(newPosition.x, rb.velocity.y, rb.velocity.z), 60f);
            }
            MoveForward();
        }
    }
    private void MoveForward()
    {
        rb.AddForce(Vector3.forward * 15000 * Time.deltaTime);
        if (rb.velocity.z > speed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }
}
