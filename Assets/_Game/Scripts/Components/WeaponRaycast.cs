using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireFlash;
    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private TrailRenderer _tracerEffect;
    private bool _isFiring;
    public void StartFiring()
    {
        _isFiring = true;
        FireBullet();
    }

    private void FireBullet()
    {
        _fireFlash.Emit(1);

        Vector3 startPos = _raycastOrigin.position;
        Vector3 endPos = _raycastOrigin.forward * 10;
        Debug.DrawRay(startPos, endPos, Color.red, 1f);
        RaycastHit hit;

        var tracer = Instantiate(_tracerEffect, _raycastOrigin.position, Quaternion.identity);
        tracer.AddPosition(_raycastOrigin.position);
        tracer.transform.SetParent(_raycastOrigin);

        if (Physics.Raycast(startPos, endPos, out hit))
        {
            Debug.Log(hit.transform.name + " was hit");
            _hitEffect.transform.position = hit.point;
            _hitEffect.transform.forward = hit.normal;
            _hitEffect.Emit(1);
            Debug.Log("Hit Point " + hit.transform.position);
            tracer.transform.position = hit.point;
        }
        else
        {
            tracer.transform.localPosition = transform.localPosition + new Vector3(0, 0, 10);
        }
    }

    public void StopFiring()
    {
        _isFiring = false;
    }
}
