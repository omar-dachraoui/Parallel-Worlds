using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private List<Image> heartsList = new List<Image>();
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
    void Damage()
    {
        
    }

}
