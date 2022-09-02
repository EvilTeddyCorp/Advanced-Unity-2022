using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public UnityEvent evt;

    public void Interact()
    {
        evt.Invoke();

    }
    
    void Update()
    {
        
    }
}
