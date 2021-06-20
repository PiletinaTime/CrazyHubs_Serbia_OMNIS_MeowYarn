using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public static float offset = -10f;

    void Update()
    {
       transform.position = target.transform.position + new Vector3(0, 4f, offset);
    }
    
}
