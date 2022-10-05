using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{
    public int RayRange = 2;
    RaycastHit2D Hit;
    LayerMask Mask;
    Movement Movement;
    public float PauseDuration = 0.2f;
    Component[] Interacts;
    bool StoppingPlayerMovement = false;
    // Update is called once per frame
    private void Start()
    {
        Movement = this.GetComponent<Movement>();
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
        if (!StoppingPlayerMovement)
        {
            Hit = Physics2D.Raycast(this.transform.position, transform.up, RayRange, Mask);
            Debug.DrawRay(this.transform.position, transform.up * RayRange, Color.green, 5);
            if (Hit)
            {
                Interacts = Hit.transform.GetComponents<interact>();
                foreach (interact Inte in Interacts)
                {
                    if (Inte.enabled == true)
                    {
                        Inte.Interact();
                        StoppingPlayerMovement = true;
                        StartCoroutine("StopPlayerMovement", PauseDuration);
                        break;
                    }
                }

            }
        }
    }
    public IEnumerator StopPlayerMovement(float duration)
    {
        Movement.enabled = false;
        this.GetComponent<Rigidbody2D>().velocity *= 0;
        yield return new WaitForSeconds(duration);
        Movement.enabled = true;
        StoppingPlayerMovement = false;
    }


}
