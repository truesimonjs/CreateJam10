using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    [SerializeField] private GameObject healthSliderObj;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = maxHealth;

        healthSliderObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value == maxHealth && healthSliderObj.activeSelf)
        {
            healthSliderObj.SetActive(false);
        }
    }

    public void HealPlayer(float value)
    {
        healthSliderObj.SetActive(true);
        healthSlider.value += value;
    }
    public void DamagePlayer(float value)
    {
        healthSliderObj.SetActive(true);
        healthSlider.value -= value;
    }
}
