using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeController _cubePrefab;
    [SerializeField] private Colorist _colorist;

    public List<Rigidbody> CreateAndGetCubes(CubeController parentCube)
    {
        List<Rigidbody> createdCubes = new List<Rigidbody>();

        int maxCubes = 6;
        int minCubes = 2;
        int countCubes = Random.Range(minCubes, maxCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            CubeController newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            if (newCube.GetComponent<MeshRenderer>() && newCube.GetComponent<Rigidbody>())
            {
                newCube.transform.localScale = parentCube.gameObject.transform.localScale / 2;
                newCube.InheritSeparationChance(parentCube.SeparationChances);
                newCube.GetComponent<MeshRenderer>().material.color = _colorist.GetRandomColor();

                createdCubes.Add(newCube.GetComponent<Rigidbody>());
            }
        }

        return createdCubes;
    }
}
