using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float RotationSpeed;
    public GameObject Player;
    public GameObject CollectedDiamond;
    public GameObject Barrel;
    private void Update()
    {
        transform.Rotate(0, 0, +RotationSpeed);
    }

    public void Ker‰ys()
    {
        Debug.Log("Timantti");
        // pelaa ‰‰ni jos joskus aion teh‰
        this.gameObject.SetActive(false);
        CollectedDiamond.SetActive(true);
        Player.GetComponent<FpsController>().enabled = false;
        Barrel.SetActive(false);
    }
}
