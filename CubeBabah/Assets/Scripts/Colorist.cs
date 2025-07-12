using System.Collections.Generic;
using UnityEngine;

public class Colorist : MonoBehaviour
{
    [SerializeField] private List<Color> _basicColors = new List<Color>()
        {
            Color.red, Color.yellow, Color.green, Color.green, Color.cyan, Color.blue, Color.magenta, Color.black, Color.white
        };

    public Color GetRandomColor()
    {
        Color color = Color.clear;

        if (_basicColors.Count > 0)
        {
            color = _basicColors[Random.Range(0, _basicColors.Count)];
        }

        return color;
    }
}
