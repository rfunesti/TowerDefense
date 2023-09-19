using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth = 10;

    public UnityEvent OnTakeDamage = new UnityEvent(); // Optional
    public UnityEvent OnZeroHealth = new UnityEvent(); // Optional
   
    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
        OnTakeDamage.Invoke();
        
        if (currentHealth <= 0 )
        {
            OnZeroHealth.Invoke();
            Destroy(gameObject);
        }
    }

    public static void TryDamage(GameObject target, int damageAmount)
    {
        Health health = target.GetComponent<Health>();

        if (health) health.TakeDamage(damageAmount);
    }


}
