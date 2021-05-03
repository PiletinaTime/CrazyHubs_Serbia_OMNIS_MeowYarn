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
        if (Settings.startGame)
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
                        newPosition.x = 0;
                        break;
                    case TouchPhase.Stationary:
                        newPosition.x = 0;
                        break;
                }
                rb.velocity = Vector3.ClampMagnitude(new Vector3(newPosition.x, rb.velocity.y, 0), 60f);
            }
            MoveForward();
            RotateYarn();
        }
    }
    private void MoveForward()
    {
        Vector3 move = (Vector3.forward) * speed * Time.deltaTime;
        transform.Translate(move);
    }
    private void RotateYarn()
    {
        transform.GetChild(1).Rotate(2f, 0, 0);
    }
}
