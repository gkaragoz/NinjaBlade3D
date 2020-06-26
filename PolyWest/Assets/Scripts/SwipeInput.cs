using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    public bool canInput = true;
    public PlayerMove playerMove;
    public TransformToRay transformToRay;
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    private void Start()
    {
        canInput = true;
    }
    private void Update()
    {
        if (canInput)
        {
            Swipe();

        }
    }
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {

                playerMove.MoveToPos(transformToRay.GetTargetPosition(Vector3.forward));

            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {

                playerMove.MoveToPos(transformToRay.GetTargetPosition(Vector3.back));

            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {

                playerMove.MoveToPos(transformToRay.GetTargetPosition(Vector3.left));
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {

                playerMove.MoveToPos(transformToRay.GetTargetPosition(Vector3.right));

            }
        }
    }

}