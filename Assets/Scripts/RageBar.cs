using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = 100;
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
