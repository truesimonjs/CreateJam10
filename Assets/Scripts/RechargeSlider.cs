using UnityEngine;
using UnityEngine.UI;

public class RechargeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = 0;
    }

    public void SubtractFromRageSlider(int value)
    {
        slider.value -= value;
    }
    public void AddToRageSlider(int value)
    {
        slider.value += value;
    }
}
