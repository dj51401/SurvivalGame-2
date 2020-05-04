using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Slider healthBar;

    // Start is called before the first frame update
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
    }
    public void SetHealth(int health)
    {
        healthBar.value = health;
    }


}
