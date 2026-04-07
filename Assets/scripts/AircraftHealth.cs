using UnityEngine;
using UnityEngine.UI; 
public class AircraftHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    
    [SerializeField] private Slider healthSlider; 
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

        public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        // Can eksiye dusmesin
        if (currentHealth < 0) currentHealth = 0;
        
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Aircraft Crashed!");
        }
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
}