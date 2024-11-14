using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergieBarUI : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private List<Image> specialAttackIconList = new List<Image>();
    int ammo;
    int maxAmmo = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammo = playerActions.specialAttackAmmo;
        
        if(maxAmmo > ammo)
        {
            specialAttackIconList[(maxAmmo-ammo)-1].enabled = false;
        }
        
    }
}
