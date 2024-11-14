using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfCoinsUI : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private Text numberOfCoinsText;

    // Update is called once per frame
    void Update()
    {
        numberOfCoinsText.text =""+playerActions.numberOfCoins;   
    }
}
