using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense {
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

            if (currentHealth <= 0)
            {
                OnZeroHealth.Invoke();
                Destroy(gameObject);
            }
        }

        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health health = target.GetComponent<Health>();
            //Debug.Log($"target: {target.name}");
            if (health)
            {
                //Debug.Log($"target: {damageAmount}");
                health.TakeDamage(damageAmount);
            }
        }
    }
}
