using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPlacement : AbilityPlacement
{
    [SerializeField] private GameObject _fireBall = null;
    private FireballAbility _abilityToAdd = null;
    private ForceFieldAbility _abilityToCheck  = null;

    private void OnTriggerEnter(Collider other)
    {
        if (!AlreadyHaveAnotherAbility(other, _abilityToCheck))
        {
            AddAbility(other, _abilityToAdd);
            if (other.gameObject.GetComponent<FireballAbility>() && other.gameObject.GetComponent<FireballAbility>().FireBall == null)
                other.gameObject.GetComponent<FireballAbility>().FireBall = _fireBall;
        }
    }
}