using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    private float LaunchSpeed = 14;
    private bool preDropPlanet;
    private readonly float maxLeftPosition = -21f;
    private readonly float maxRightPosition = 21f;
    private bool movingRight;
    private Vector3 plantLaunchPosition;

    public void LaunchPlanet()
    {
        preDropPlanet = true;
        movingRight = true;
        plantLaunchPosition = plantLaunchPosition = new Vector3(maxLeftPosition, 10.5f, 0f);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void DropPlanet()
    {
        preDropPlanet = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    void Update()
    {
        if(preDropPlanet)
        {
            transform.position = plantLaunchPosition;
            plantLaunchPosition.x += LaunchSpeed * Time.deltaTime * (movingRight ? 1 : -1);
            if(plantLaunchPosition.x <= maxLeftPosition)
                movingRight = true;
            if(plantLaunchPosition.x >= maxRightPosition)
                movingRight = false;
        }
    }

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
