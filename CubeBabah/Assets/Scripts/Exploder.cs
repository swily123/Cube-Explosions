using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Zoner _zoner;
    [SerializeField] private Effector _effector;
    private const float _explosionForce = 100;
    private const float _explosionRadius = 3;

    public void Explode(Transform explosionPoint, List<Cube> cubes, float explosionForce = _explosionForce, float explosionRadius = _explosionRadius)
    {
        foreach (Cube explodableObject in cubes)
        {
            if (explodableObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explosionForce, explosionPoint.position, explosionRadius);
            }
        }
    }

    public void Explode(Transform explosionPoint, int indexEffect, float explosionForce, float explosionRadius)
    {
        List<Cube> cubesToExplode = _zoner.GetCubesInRadius(explosionPoint, explosionRadius);
        ParticleSystem effect = _effector.GetEffectByIndex(indexEffect);

        if (effect != null)
        {
            Instantiate(effect, explosionPoint.position, explosionPoint.rotation);
        }

        Explode(explosionPoint, cubesToExplode, explosionForce, explosionRadius);
    }
}
