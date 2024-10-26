using UnityEngine;
using UnityEngine.Events;

public class MusicCollider : MonoBehaviour
{
    private BoxCollider2D collider2D;
    public UnityEvent<bool> musicColliderInside;
    public UnityEvent<float> musicColliderDistance;
    void Start()
    {
        this.collider2D = GetComponent<BoxCollider2D>();
        if(musicColliderInside == null)
        {
            musicColliderInside = new UnityEvent<bool>();
        }
        if(musicColliderDistance == null)
        {
            musicColliderDistance = new UnityEvent<float>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        musicColliderInside.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        musicColliderInside.Invoke(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float thisCenter = collider2D.bounds.center.x;
        float otherCenter = collision.bounds.center.x;
        float distance = Mathf.Min(Mathf.Abs(thisCenter - otherCenter), 1);
        musicColliderDistance.Invoke(distance);
    }

    public void onDoorOpenEventInvoke()
    {
        Debug.Log("onDoorOpenEventInvoke called");
        collider2D.enabled = true;
    }
}
