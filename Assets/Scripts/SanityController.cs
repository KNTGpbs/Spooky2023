using System;
using UnityEngine;
using UnityEngine.Events;

public class SanityController : MonoBehaviour
{

    public UnityEvent e9, e8, e7, e6, e5, e4, e3, e2, e1, e0;
    private bool[] isEventInvoke = { false, false, false, false, false, false, false, false, false, false};
    
    [SerializeField] private float initialSanityPoints = 10000f;
    [SerializeField] private float sanityReductionMultipler = 1;
    [SerializeField] private float wrongItemPenalty = 100f;
    [SerializeField] private EndingController endingController;

    private float sanityPoints;
    
    void Start()
    {
        sanityPoints = initialSanityPoints;
    }

    private void FixedUpdate()
    {
        sanityPoints -= Time.deltaTime * sanityReductionMultipler;
        if (sanityPoints <= 0)
        {
            endingController.TriggerEnding(Ending.SanityOver);
        }
    }

    public void ModifySanityReductionMultiply(float newSanityReductionMultiplier)
    {
        sanityReductionMultipler = newSanityReductionMultiplier;
    }

    public void ItemUseFailed()
    {
        ModifySanity(-wrongItemPenalty);
    }

    public void ModifySanity(float modifier)
    {
        sanityPoints += modifier;
        if (modifier > 0) {
            
        }
        else
        {
            if (sanityPoints < 9000 && !isEventInvoke[9]) {
                e9.Invoke();
                isEventInvoke[9] = true;
            }
            if (sanityPoints < 8000 && !isEventInvoke[8])
            {
                e8.Invoke();
                isEventInvoke[8] = true;
            }
            if (sanityPoints < 7000 && !isEventInvoke[7])
            {
                e7.Invoke();
                isEventInvoke[7] = true;
            }
            if (sanityPoints < 6000 && !isEventInvoke[6])
            {
                e6.Invoke();
                isEventInvoke[6] = true;
            }
            if (sanityPoints < 5000 && !isEventInvoke[5])
            {
                e5.Invoke();
                isEventInvoke[5] = true;
            }
            if (sanityPoints < 4000 && !isEventInvoke[4])
            {
                e4.Invoke();
                isEventInvoke[4] = true;
            }
            if (sanityPoints < 3000 && !isEventInvoke[3])
            {
                e3.Invoke();
                isEventInvoke[3] = true;
            }
            if (sanityPoints < 2000 && !isEventInvoke[2])
            {
                e2.Invoke();
                isEventInvoke[2] = true;
            }
            if (sanityPoints < 1000 && !isEventInvoke[1])
            {
                e1.Invoke();
                isEventInvoke[1] = true;
            }
            if (sanityPoints < 0 && !isEventInvoke[0])
            {
                e0.Invoke();
                isEventInvoke[0] = true;
            }
        }
    }
}
