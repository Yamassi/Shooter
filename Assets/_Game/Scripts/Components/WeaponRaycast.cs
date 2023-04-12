using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireFlash;
    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private ParticleSystem _hitEffect;
    private bool _isFiring;
    public void StartFiring()
    {
        _isFiring = true;
        _fireFlash.Emit(1);

        Vector3 startPos = _raycastOrigin.position;
        Vector3 endPos = _raycastOrigin.forward * 10;
        Debug.DrawRay(startPos, endPos, Color.red, 1f);
        RaycastHit hit;
        if (Physics.Raycast(startPos, endPos, out hit))
        {
            Debug.Log(hit.transform.name + " was hit");
            _hitEffect.transform.position = hit.point;
            _hitEffect.transform.forward = hit.normal;
            _hitEffect.Emit(1);
        }
    }
    public void StopFiring()
    {
        _isFiring = false;
    }
}
