using Mono.Cecil.Cil;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class AnchorLogic : MonoBehaviour
{
    public UnityEvent<Vector2> actionStart = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> actionStop = new UnityEvent<Vector2>();
    private List<DoorOpen> actionScripts = new List<DoorOpen>();

    void Start()
    {
        actionScripts = GetComponentsInChildren<DoorOpen>().ToList();
        foreach (var doorOpen in actionScripts)
        {
            doorOpen.enterEvent.AddListener(CheckAndMoveOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void CheckAndMoveOn(DoorOpen component)
    {
        Vector2 eventActionAnchor = component.transform.position;
        Debug.Log(eventActionAnchor);
        actionStart.Invoke(eventActionAnchor);

        foreach (var doorOpen in actionScripts)
        {
            if (doorOpen == component)
            {
                Vector2 nextActionAnchor = actionScripts[(actionScripts.IndexOf(doorOpen) + 1) % actionScripts.Count()].transform.position;
                await Task.Delay(2000);
                Debug.Log(nextActionAnchor);
                actionStop.Invoke(nextActionAnchor);
            }
        }
    }
}
