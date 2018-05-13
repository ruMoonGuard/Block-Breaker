using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool IsAutomaticPlay = false;

    private Ball ball;

	void Start ()
    {
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsAutomaticPlay)
        {
            MoveAutomatic();
        }
        else
        {
            MoveWithMouse();
        }
	}

    void MoveAutomatic()
    {
        var ballPosition = Mathf.Clamp(ball.transform.position.x, 0f, 15f);

        this.transform.position = new Vector3(ballPosition, this.transform.position.y, 0f);
    }

    void MoveWithMouse()
    {
        var mousePositionToBlock = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 16, 0f, 15f);

        this.transform.position = new Vector3(mousePositionToBlock, this.transform.position.y, 0f);
    }
}
