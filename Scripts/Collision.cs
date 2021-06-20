using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Renderer rend, rend1;
    [SerializeField]
    private Transform Cat;
    private bool ableToCollide = true;
    public static bool finish;
    public static int collectibleValue = 30;
    void Start()
    {
        rend = Cat.GetComponent<Renderer>();
        rend1 = transform.GetComponent<Renderer>();
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
        rend.enabled = rend1.enabled = ableToCollide = true;
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
        if (other.CompareTag("Point"))
        {
            Health.ChangeValue(collectibleValue);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Needles") && ableToCollide)
        {
            Health.ChangeValue(-45);
            StartCoroutine(CharacterBlink(4, 0.2f));
            Handheld.Vibrate();
        }
        else if ((other.CompareTag("Blades") || other.CompareTag("Obstacle")) && ableToCollide)
        {
            Health.ChangeValue(-25);
            StartCoroutine(CharacterBlink(4, 0.2f));
            Handheld.Vibrate();
        }
        else if (other.CompareTag("Trigger"))
        {
            StartCoroutine(MoveTrap(other.gameObject, other.gameObject.transform.position + Vector3.up));
        }
        else if (other.CompareTag("Finish"))
        {
            StartCoroutine(Health.ReduceHealthGradually(40));
        }
        else if (other.CompareTag("Multiplier"))
        {
            finish = true;
            StopCoroutine(Health.reduceHP);
            Movement.speed = 10;
        }
    }
}


