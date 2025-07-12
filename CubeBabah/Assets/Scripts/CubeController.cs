using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeDetector _clickHandler;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    public int SeparationChances { get; private set; } = 100;
    private const int _maxSeparationsChance = 100;

    public void InheritSeparationChance(int parentChance)
    {
        int decreaseCoefficient = 2;
        SeparationChances = parentChance / decreaseCoefficient;
    }

    private void OnEnable()
    {
        _clickHandler.CubeDetected += OnClick;
    }

    private void OnDisable()
    {
        _clickHandler.CubeDetected -= OnClick;
    }

    private void OnClick(CubeController clickedCube)
    {
        if (clickedCube == this)
        {
            TrySeparation(clickedCube);
            Destroy(clickedCube.gameObject);
        }
    }

    private void TrySeparation(CubeController cube)
    {
        bool shouldSeparate = Random.Range(0f, _maxSeparationsChance) < cube.SeparationChances;

        if (shouldSeparate)
        {
            List<Rigidbody> spawnedCubes = _spawner.CreateAndGetCubes(cube);
            _exploder.Explode(spawnedCubes);
        }
        else
        {
            Debug.Log($"Не получилось разделить куб. У него был Шанс успеха: {cube.SeparationChances}%.");
        }
    }
}
