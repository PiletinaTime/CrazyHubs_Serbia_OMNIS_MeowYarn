using UnityEngine;

public class FollowYarn : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - 4f);
    }
}
