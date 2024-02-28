using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        switch(collider.tag)
        {
            case "SCORE1" : Debug.Log("Score 1");
            break;
            case "SCORE5" : Debug.Log("Score 5");
            break;
            case "SCORE10" : Debug.Log("Score 10");
            break;
        }
    }
}
