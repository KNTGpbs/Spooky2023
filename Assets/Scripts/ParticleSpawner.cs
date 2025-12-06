using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab;

    public void PlayParticles()
    {
        Instantiate(particlePrefab, transform.position + Vector3.back, Quaternion.identity);
    }
}
