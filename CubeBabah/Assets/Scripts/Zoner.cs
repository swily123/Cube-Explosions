using System.Collections.Generic;
using UnityEngine;

public class Zoner : MonoBehaviour
{
    public List<Cube> GetCubesInRadius(Transform point, float radius)
    {
        Collider[] hits = Physics.OverlapSphere(point.position, radius);
        List<Cube> cubes = new List<Cube>();

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<Cube>(out Cube cube))
            {
                cubes.Add(cube);
            }
        }

        return cubes;
    }
}
