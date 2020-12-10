using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public Transform heartContainer;
    public GameObject heartPrefab;
    
    
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        for (var i = 0; i < maxHealth; i++)
        {
            Instantiate(heartPrefab, heartContainer);
        }
    }

    private void Update()
    {
        for (var i = 0; i < heartContainer.childCount; i++)
        {
            if (i < _currentHealth)
                heartContainer.GetChild(i).GetComponent<Image>().enabled = true;
            else
            {
                heartContainer.GetChild(i).GetComponent<Image>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && _currentHealth >= 0)
        {
            _currentHealth--;
        }

        
    }
}
