using System.Data.SqlTypes;
using UnityEngine;

public abstract class AbilityPlacement : MonoBehaviour
{
    protected void AddAbility<T>(Collider other, T component) where T : MonoBehaviour
    {
        if (other.GetComponent<PlayerInputProvider>() && !other.GetComponent<T>())
            other.gameObject.AddComponent<T>();
        else if (other.GetComponent<PlayerInputProvider>() && other.GetComponent<T>())
            other.GetComponent<T>().enabled = true;
    }

    protected bool AlreadyHaveAnotherAbility<T>(Collider other, T abilityScript) where T : MonoBehaviour
    {
        return other.GetComponent<T>() && other.GetComponent<T>().enabled;
    }
}