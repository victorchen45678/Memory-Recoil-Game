using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider HealthSlider;
    public Color MinHealth;
    public Color MaxHealth;
    public Vector3 SliderTop;
    // Start is called before the first frame update
    void Start()
    {
        SliderTop.y = transform.parent.localScale.y / 2;
    }

    public void SetHealth(float health, float maximum)
    {
        HealthSlider.gameObject.SetActive(health < maximum);
        HealthSlider.value = health;
        HealthSlider.maxValue = maximum;

        HealthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(MinHealth, MaxHealth, HealthSlider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + SliderTop);
    }
}
