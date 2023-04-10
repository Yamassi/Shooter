using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireFlash;

    private bool _isFiring;
    public void StartFiring()
    {
        _isFiring = true;
        _fireFlash.Emit(1);
    }
    public void StopFiring()
    {
        _isFiring = false;
    }
}
