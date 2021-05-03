using UnityEngine;

public class Needles : MonoBehaviour
{
    private float min, max, startTime;
    public static float speed;
    void Start()
    {
        min = transform.position.x;
        if (min < 0) max = transform.position.x - 5;
        else max = transform.position.x + 5;
        speed = Random.Range(2, 7);
        startTime = Random.Range(0, 4);
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.SmoothStep(min, max, Mathf.PingPong((Time.time - startTime) / speed, 1)), transform.position.y, transform.position.z);
    }
}