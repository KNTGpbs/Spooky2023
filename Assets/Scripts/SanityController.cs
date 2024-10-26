using System;
using UnityEngine;

public class SanityController : MonoBehaviour
{
    
    [SerializeField] private float initialSanityPoints = 10000f;
    [SerializeField] private float sanityReductionMultipler = 1;
    [SerializeField] private float wrongItemPenalty = 10;

    private float sanityPoints;
    
    void Start()
    {
        sanityPoints = initialSanityPoints;
    }

    private void FixedUpdate()
    {
        sanityPoints -= Time.deltaTime * sanityReductionMultipler;
        //Debug.Log(sanityPoints);
    }

    public void ModifySanityReductionMultiply(float newSanityReductionMultiplier)
    {
        sanityReductionMultipler = newSanityReductionMultiplier;
    }

    public void ItemUseFailed()
    {
        sanityPoints -= sanityReductionMultipler * wrongItemPenalty;
    }
}
