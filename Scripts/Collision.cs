using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Renderer rend, rend1;
    private bool ableToCollide = true;
    public static bool finish;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend1 = transform.parent.GetComponent<Renderer>();
        finish = false;
    }
    IEnumerator CharacterBlink(int numBlinks, float seconds)
    {
        ableToCollide = false;
        for (int i = 0; i < numBlinks * 2; i++)
        {
            rend.enabled = !rend.enabled;
            rend1.enabled = !rend1.enabled;
            yield return new WaitForSeconds(seconds);
        }
        rend.enabled = true;
        rend1.enabled = true;
        ableToCollide = true;
    }
    public IEnumerator MoveTrap(GameObject obj, Vector3 destination)
    {
        float totalMovementTime = 1f;
        float currentMovementTime = 0f;
        while (Vector3.Distance(obj.transform.position, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(obj.transform.position, destination, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Health health = transform.GetComponent<Health>();
        if (other.CompareTag("Point"))
        {
            health.ChangeValue(40);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Needles") && ableToCollide)
        {
            health.ChangeValue(-80);
            StartCoroutine(CharacterBlink(4, 0.2f));
            Handheld.Vibrate();
        }
        else if ((other.CompareTag("Blades") || other.CompareTag("Obstacle")) && ableToCollide)
        {
            health.ChangeValue(-40);
            StartCoroutine(CharacterBlink(4, 0.2f));
            Handheld.Vibrate();
        }
        else if (other.CompareTag("Trigger"))
        {
            StartCoroutine(MoveTrap(other.gameObject, other.gameObject.transform.position + Vector3.up));
        }
        else if (other.CompareTag("Finish"))
        {
            StartCoroutine(health.ReduceHealthGradually(45));
        }
        else if (other.CompareTag("OutOfBounds"))
        {
            transform.parent.parent.GetComponent<Settings>().GameOver();
        }
        else if (other.CompareTag("Multiplier"))
        {
            finish = true;
            StopCoroutine(health.reduceHP);
            Movement.speed = 10;
        }
    }
}


