using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _explosionEffect;

    public ParticleSystem GetEffectByIndex(int index)
    {
        ParticleSystem effect = null;

        if (index >= 0 && index < _explosionEffect.Count)
        {
            effect = _explosionEffect[index];
        }

        return effect;
    }
}
