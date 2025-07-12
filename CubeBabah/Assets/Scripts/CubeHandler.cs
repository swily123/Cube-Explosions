using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeDetector _cubeDetector;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private const int _maxSeparationsChance = 100;

    private void OnEnable()
    {
        _cubeDetector.CubeDetected += OnClick;
    }

    private void OnDisable()
    {
        _cubeDetector.CubeDetected -= OnClick;
    }

    private void OnClick(Cube clickedCube)
    {
        TrySeparation(clickedCube);
        Destroy(clickedCube.gameObject);
    }

    private void TrySeparation(Cube cube)
    {
        bool shouldSeparate = Random.Range(0f, _maxSeparationsChance) < cube.SeparationChances;

        if (shouldSeparate)
        {
            List<Cube> spawnedCubes = _spawner.Spawn(cube);
            _exploder.Explode(cube.transform, spawnedCubes);
        }
        else
        {
            Debug.Log($"Не получилось разделить куб. У него был Шанс успеха: {cube.SeparationChances}%.");
            _exploder.Explode(cube.transform, 0, cube.PotentialExplosionForce, cube.PotentialExplosionRadius);
        }
    }
}
