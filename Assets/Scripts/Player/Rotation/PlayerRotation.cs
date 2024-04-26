using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _time;
    
    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if(inputHorizontal != 0 || inputVertical != 0)
           transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}
