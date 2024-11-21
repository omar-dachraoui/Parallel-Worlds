using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] float yRange = 0.5f;
    [SerializeField]private PlayerAtPositionButtonCheck firePlayerAtPositionButtonCheck;
    [SerializeField]private PlayerAtPositionButtonCheck icePlayerAtPositionButtonCheck;
    bool LevelCompletedCheck = false;



    void Update()
    {
        if(!LevelCompletedCheck)
        {
            LevelCompleted();
            
        }
        
    }




    private void LevelCompleted()
    {
        if(firePlayerAtPositionButtonCheck!=null && icePlayerAtPositionButtonCheck!=null)
        {
            if(firePlayerAtPositionButtonCheck.playerAtPosition && icePlayerAtPositionButtonCheck.playerAtPosition)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - yRange, this.transform.position.z);
                LevelCompletedCheck = true;
            }
            else
            {
                LevelCompletedCheck = false;
                return ;
            }
        }
        
        
    }
}
