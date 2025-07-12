using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3;
    [SerializeField] private float _explosionForce = 100;

    public void Explode(List<Rigidbody> cubes)
    {
        foreach (Rigidbody explodableObject in cubes)
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
