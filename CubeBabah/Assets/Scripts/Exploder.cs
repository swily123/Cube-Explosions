using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3;
    [SerializeField] private float _explosionForce = 100;

    public void Explode(List<Cube> cubes)
    {
        foreach (Cube explodableObject in cubes)
        {
            if (explodableObject.GetComponent<Rigidbody>())
            {
                explodableObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
