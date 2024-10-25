using UnityEngine;

public class SoftPositionConnection : MonoBehaviour
{
    [SerializeField] private float softSpeed;
    [SerializeField] private GameObject ObjectToFollow;

    [SerializeField] private bool isSoft = true;
    void FixedUpdate()
    {
        if (isSoft)
        {
            transform.position = Vector3.Lerp(transform.position, ObjectToFollow.transform.position, softSpeed * Time.deltaTime); 
        }
        else
        {
            transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, ObjectToFollow.transform.position.z);
        }
    }
}
