using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private List<Image> heartsList = new List<Image>();
    int health;
    int maxHealth = 4;
    // Start is called before the first frame update
    void Start()
    {
        if(heartsList.Count == 0)
        {
            Debug.LogError("No hearts found in the list");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        
        if(maxHealth > health)
        {
            heartsList[(maxHealth-health)-1].enabled = false;
        }
    }

}
