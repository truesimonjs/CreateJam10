using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{

    public static RageBar instance;
    UIController UI;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = 0;
        UI = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    public void SubtractFromRageSlider(int value)
    {
        slider.value -= value;
    }
    public void AddToRageSlider(int value)
    {
        slider.value += value;
    }

    void Update()
    {
        if (slider.value >= 100)
        {
            StartCoroutine(AppQuit());
        }
    }

    IEnumerator AppQuit()
    {
        UI.OpenVictoryScreen();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5);
        Application.Quit();
    }
}
