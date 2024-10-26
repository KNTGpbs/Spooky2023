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
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            pos = Vector2.Lerp(pos, new Vector2(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y), softSpeed * Time.deltaTime);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, transform.position.z);
        }
    }
}
