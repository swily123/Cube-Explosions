using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    public int SeparationChances { get; private set; } = 100;
    public float PotentialExplosionRadius { get; private set; } = 2;
    public float PotentialExplosionForce{ get; private set; } = 100;


    public void InheritParentCharacteristics(int parentChance, float parentRadius, float parentForce)
    {
        int chanceCoefficient = 2;
        int radiusValue = 2;
        int forceValue = 50;

        SeparationChances = parentChance / chanceCoefficient;
        PotentialExplosionRadius += parentRadius + radiusValue;
        PotentialExplosionForce += parentForce + forceValue;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, PotentialExplosionRadius);
    }
}
