using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _explosionRadius = 3;
    private float _explosionForce = 100;
    private int _separationChances = 100;

    public void InheritSeparationChance(int parentChance)
    {
        int decreaseCoefficient = 2;
        _separationChances = parentChance / decreaseCoefficient;
    }

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
        TrySeparation();
    }

    private void TrySeparation()
    {
        bool shouldSeparate = Random.Range(0f, 100f) < _separationChances;

        if (shouldSeparate)
        {
            Explode(CreateAndGetCubes());
        }
        else
        {
            Debug.Log($"Не получилось разделить куб. У него был Шанс успеха: {_separationChances}%.");
        }
    }

    private List<Rigidbody> CreateAndGetCubes()
    {
        List<Rigidbody> createdCubes = new List<Rigidbody>();

        int maxCubes = 6;
        int minCubes = 2;
        int countCubes = Random.Range(minCubes, maxCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            newCube.gameObject.transform.localScale = gameObject.transform.localScale / 2;
            newCube.GetComponent<MeshRenderer>().material.color = GetRandomColor();
            newCube.InheritSeparationChance(_separationChances);

            createdCubes.Add(newCube.GetComponent<Rigidbody>());
        }

        return createdCubes;
    }

    private Color GetRandomColor()
    {
        List<Color> colors = new List<Color>()
        {
            Color.red, Color.yellow, Color.green, Color.green, Color.cyan, Color.blue, Color.magenta, Color.black, Color.white
        };
        Color color = Color.clear;

        if (colors.Count > 0)
        {
            color = colors[Random.Range(0, colors.Count)];
        }

        return color;
    }

    private void Explode(List<Rigidbody> cubes)
    {
        foreach (Rigidbody explodableObject in cubes)
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
