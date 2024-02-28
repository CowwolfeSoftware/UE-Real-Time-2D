using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        switch(collider.gameObject.tag)
        {
            case "SCORE1" : 
                ScoreBoard.Instance.IncrementScore(1);
                Destroy(gameObject);
                break;

            case "SCORE5" :
                ScoreBoard.Instance.IncrementScore(5);
                Destroy(gameObject);
                break;
            
            case "SCORE10" :
                ScoreBoard.Instance.IncrementScore(10);
                Destroy(gameObject);
                break;
            
            case "SCORE0" :
                Destroy(gameObject);
                break;
        }
    }
}
