using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DoorTrigger : MonoBehaviour
{
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Interact();
   
        }        
    }

 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            InteractClose();
      
        }
    }


    public UnityEvent Evt;
    public UnityEvent ClosingEvt;
    public void Interact()
    {
        Evt.Invoke();

    }
    public void InteractClose()
    {
        ClosingEvt.Invoke();

    }

}
