using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [HideInInspector]
    public float maxHealth = 100f;
    public float curHealth;
    public Image healthBarFill;
    public TextMeshProUGUI healthno;


    public float damageAmt = 10f;
    public float regenerationRate = 5f;

    void Start()
    {
        curHealth = maxHealth;
        
        UpdateHealthBar();
    }

   
    void Update()
    {
        RegenerateHealth();
    }
    public void TakeDamage(float amount)
    {
        curHealth -= amount;
        if (curHealth <= 0f)
        {
            // Handle player death (reload scene, game over, etc.)
        }
        UpdateHealthBar();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {

            TakeDamage(other.GetComponent<DamageTrap>()?.damageAmount ?? 20f); // Get damage from trap or use default
        }
    }

    void RegenerateHealth()
    {
        if (curHealth < maxHealth)
        {
            curHealth += regenerationRate * Time.deltaTime;
            curHealth = Mathf.Clamp(curHealth, 0f, maxHealth);
            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        healthno.text = curHealth.ToString("F0");
        healthBarFill.fillAmount = curHealth / maxHealth;
    }
}
