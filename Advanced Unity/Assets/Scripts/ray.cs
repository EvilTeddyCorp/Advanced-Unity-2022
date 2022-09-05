using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{
    public int RayRange = 5;
    RaycastHit2D Hit;
    LayerMask Mask;
    // Update is called once per frame
    private void Start()
    {
        Mask = LayerMask.GetMask("Interactable", "Wall");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }


    }

    void Interact()
    {
        Hit = Physics2D.Raycast(this.transform.position, transform.up, 20f, Mask );
        Debug.DrawRay(this.transform.position, transform.up * RayRange, Color.green, 5);
        if (Hit)
        {
            
            if (Hit.transform.GetComponent<interact>())
            {
                Hit.transform.GetComponent<interact>().Interact();
            }
            
        }

    }


}
