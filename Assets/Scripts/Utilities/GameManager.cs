using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform endOfGameUI;
    [SerializeField] private Transform player1Health;
    [SerializeField] private Transform player2Health;
    // Start is called before the first frame update
    void Start()
    {
        endOfGameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if(player1Health.gameObject.activeSelf == false || player2Health.gameObject.activeSelf == false)
        {
            endOfGameUI.gameObject.SetActive(true);
        }
    }
}
