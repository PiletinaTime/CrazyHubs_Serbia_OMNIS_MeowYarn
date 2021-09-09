using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OutOfBounds"))
        {
            GameManager.GameOver();
        }
    }
}
