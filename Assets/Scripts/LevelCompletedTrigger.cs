using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedTrigger : MonoBehaviour
{
    [SerializeField] private Transform levelCompletedPanel;
    [SerializeField] private Text levelCompletedText;
    PlayerActions playerActions ;
   void OnTriggerEnter2D(Collider2D other)
    {
       playerActions = other.GetComponent<PlayerActions>();
       if(playerActions != null)
       {
            playerActions.transform.gameObject.SetActive(false);
            levelCompletedText.text = "YOU WIN!";
            levelCompletedPanel.gameObject.SetActive(true);
           Debug.Log("Level completed!");
       }
    }
}
