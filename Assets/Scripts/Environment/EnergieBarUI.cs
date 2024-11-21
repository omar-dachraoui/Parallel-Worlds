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
    
    // Update is called once per frame
    void Update()
    {
        ammo = playerActions.specialAttackAmmo;
        if(ammo == 0)
        {
            foreach (var icon in specialAttackIconList)
            {
                icon.enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < ammo; i++)
            {
                specialAttackIconList[i].enabled = true;
            }
        }
        
        if(maxAmmo > ammo)
        {
            specialAttackIconList[(maxAmmo-ammo)-1].enabled = false;
        }

       
        
    }


 
}
