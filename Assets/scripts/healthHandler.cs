using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        float health = 1f;
        healthBar.SetSize(health);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
