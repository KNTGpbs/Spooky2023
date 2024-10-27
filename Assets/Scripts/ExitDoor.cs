using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : SpecialItemTarget
{
    public override void Use(ItemData item)
    {
        EndingController.FindInstance().TriggerEnding(Ending.ExitDoor);
    }
}