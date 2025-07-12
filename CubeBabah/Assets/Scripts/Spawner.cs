using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Colorist _colorist;

    public List<Cube> Spawn(Cube parentCube)
    {
        List<Cube> createdCubes = new List<Cube>();

        int maxCubes = 6;
        int minCubes = 2;
        int countCubes = Random.Range(minCubes, maxCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            Cube newCube = Instantiate(parentCube, parentCube.transform.position, Quaternion.identity);

            if (newCube.TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
            {
                newCube.transform.localScale = parentCube.gameObject.transform.localScale / 2;
                newCube.InheritParentCharacteristics(parentCube.SeparationChances, parentCube.PotentialExplosionRadius, parentCube.PotentialExplosionForce);
                meshRenderer.material.color = _colorist.GetRandomColor();

                createdCubes.Add(newCube.GetComponent<Cube>());
            }
        }

        return createdCubes;
    }
}