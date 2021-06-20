using UnityEngine;

public class Blades : MonoBehaviour
{
    private float firstChildMinPos,secondChildMinPos, startTime, maxPos;
    public static float speed;
    private Transform firstChild, secondChild;
    private void Awake()
    {
        firstChild = transform.GetChild(0).transform;
        secondChild = transform.GetChild(1).transform;
        firstChildMinPos = firstChild.position.x;
        secondChildMinPos = secondChild.position.x;
        maxPos = firstChild.localScale.x;
        speed = Random.Range(3, 7);
        startTime = Random.Range(0, 4);
    }
    private void Update()
    {
        firstChild.position = new Vector3(Mathf.SmoothStep(firstChildMinPos, -maxPos, Mathf.PingPong((Time.time - startTime) / speed, 1)), firstChild.position.y, firstChild.position.z);
        secondChild.position = new Vector3(Mathf.SmoothStep(secondChildMinPos, maxPos, Mathf.PingPong((Time.time - startTime) / speed, 1)), secondChild.position.y, secondChild.position.z);
        firstChild.Rotate(0, 0, -2);
        secondChild.Rotate(0, 0, -2);
    }
}
