using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        float health = 1f;
        healthBar.SetSize(health);
    }
}
