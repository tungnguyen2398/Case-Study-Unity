using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image hpMain;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    public void UpdateHealthBar(float percent)
    {
        hpMain.fillAmount = percent;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
