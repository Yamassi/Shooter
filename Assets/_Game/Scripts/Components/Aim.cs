using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class Aim : MonoBehaviour, IAim
{
    [SerializeField] private WeaponRaycast _weaponRaycast;
    [SerializeField] private Rig _aimLayer;
    [SerializeField] private float _aimDuration = 0.3f;
    public void SetAim(bool isFiring)
    {
        if (isFiring)
        {
            _aimLayer.weight += Time.deltaTime / _aimDuration;

            if (_aimLayer.weight == 1)
                _weaponRaycast.StartFiring();
        }
        else
        {
            _aimLayer.weight -= Time.deltaTime / _aimDuration;

            if (_aimLayer.weight < 1)
                _weaponRaycast.StopFiring();
        }
    }

}
