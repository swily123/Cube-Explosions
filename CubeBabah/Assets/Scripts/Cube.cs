using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    public int SeparationChances { get; private set; } = 100;

    public void InheritSeparationChance(int parentChance)
    {
        int decreaseCoefficient = 2;
        SeparationChances = parentChance / decreaseCoefficient;
    }
}
