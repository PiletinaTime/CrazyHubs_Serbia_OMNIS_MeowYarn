using UnityEngine;

public class Needles : MonoBehaviour
{
    private float min, max, startTime;
    public static float speed;
    void Awake()
    {
        min = transform.position.x;
        if (min < 0) max = transform.position.x - 5;
        else max = transform.position.x + 5;
        startTime = Random.Range(0, 5);
        speed = Random.Range(3, 9);
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(min, transform.position.y, transform.position.z), new Vector3(max, transform.position.y, transform.position.z), Mathf.SmoothStep(0f, 1f, Mathf.PingPong((Time.time - startTime) / speed, 1)));
    }
}