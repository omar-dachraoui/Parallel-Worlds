using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]   private Transform levelSelectUI;
    [SerializeField]   private Transform mainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        levelSelectUI.gameObject.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        levelSelectUI.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
    }
}
