using System;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] ClickHandler _clickHandler;

    public event Action<Cube> CubeDetected;

    private void OnEnable()
    {
        _clickHandler.LeftButtonClicked += TryDetectCube;
    }

    private void OnDisable()
    {
        _clickHandler.LeftButtonClicked -= TryDetectCube;
    }

    private void TryDetectCube()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.TryGetComponent<Cube>(out Cube cube))
            {
                CubeDetected?.Invoke(cube);
            }
        }
    }
}
