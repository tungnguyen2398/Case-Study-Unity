using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image hpMain;
    public void UpdateHealthBar(float percent)
    {
        hpMain.fillAmount = percent;
    }
}
