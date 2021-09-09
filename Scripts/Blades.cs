using UnityEngine;

public class Blades : MonoBehaviour
{
    private float firstChildMinPos,secondChildMinPos, startTime, maxPos;
    private Transform firstChild, secondChild;
    public static float speed;
    void Awake()
    {
        firstChild = transform.GetChild(0).transform;
        secondChild = transform.GetChild(1).transform;
        firstChildMinPos = firstChild.position.x;
        secondChildMinPos = secondChild.position.x;
        maxPos = firstChild.localScale.x;
        startTime = Random.Range(0, 5);
        speed = Random.Range(3, 9);
    }
    private void Update()
    {
        firstChild.position = new Vector3(Mathf.SmoothStep(firstChildMinPos, -maxPos, Mathf.PingPong((Time.time - startTime) / speed, 1)), firstChild.position.y, firstChild.position.z);
        secondChild.position = new Vector3(Mathf.SmoothStep(secondChildMinPos, maxPos, Mathf.PingPong((Time.time - startTime) / speed, 1)), secondChild.position.y, secondChild.position.z);
        firstChild.Rotate(0, 0, -2);
        secondChild.Rotate(0, 0, -2);
    }
}