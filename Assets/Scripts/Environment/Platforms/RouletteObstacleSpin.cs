using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteObstacleSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 1),rotationSpeed);
    }
}
