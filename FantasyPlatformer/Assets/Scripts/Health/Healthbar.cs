using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth;
    }
}
