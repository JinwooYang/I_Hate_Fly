using UnityEngine;
using System.Collections;

public enum MoveDirection { LEFT, RIGHT };

public class Fly : MonoBehaviour 
{
    public float speed;
    public float moveHeight;

    MoveDirection moveDir;

    Transform cachedTransform;

    float startPosY;
    float degAngle = 0f;

    public void Init(float posX, float posY, float newSpeed, float newMoveHeight, MoveDirection newDirection)
    {
        Vector3 tempVector = cachedTransform.position;
        tempVector.x = posX;
        tempVector.y = posY;
        cachedTransform.position = tempVector;

        startPosY = posY;

        speed = newSpeed;

        moveHeight = newMoveHeight;

        moveDir = newDirection;

        if (moveDir == MoveDirection.LEFT)
        {
            Vector3 tempScale = cachedTransform.localScale;
            tempScale.x = -tempScale.x;
            cachedTransform.localScale = tempScale;
        }

        gameObject.SetActive(true);
    }

	void Awake () 
    {
        cachedTransform = base.transform;
	}
	
	void Update () 
    {
        switch(moveDir)
        {
            case MoveDirection.LEFT:
                cachedTransform.Translate(Vector2.left * speed);
                break;

            case MoveDirection.RIGHT:
                cachedTransform.Translate(Vector2.right * speed);
                break;

            default:
                Debug.Assert(false, "moveDir변수에 예상하지 못한 값 발견");
                break;
        }

        float posY = Mathf.Sin(degAngle * Mathf.Deg2Rad) * moveHeight + startPosY;

        Vector3 tempVector = cachedTransform.position;
        tempVector.y = posY;
        cachedTransform.position = tempVector;

        degAngle += 10f;

        if(degAngle > 360f)
        {
            degAngle -= 360f;
        }
	}
}
 