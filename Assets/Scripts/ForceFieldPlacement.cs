using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldPlacement : AbilityPlacement
{
    [SerializeField] private GameObject _field = null;
    private ForceFieldAbility _abilityToAdd = null;
    private FireballAbility _abilityToCheck = null;
    private void OnTriggerEnter(Collider other)
    {
        if (!AlreadyHaveAnotherAbility(other, _abilityToCheck))
        {
            AddAbility(other, _abilityToAdd);
            if (other.gameObject.GetComponent<ForceFieldAbility>() && other.gameObject.GetComponent<ForceFieldAbility>().Shape == null) 
                other.gameObject.GetComponent<ForceFieldAbility>().Shape = _field;
        }
    }
}