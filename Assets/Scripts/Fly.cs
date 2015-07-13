using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour 
{
    public float speed;
    public float moveHeight;

    Transform cachedTransform;

    enum MoveDirection { LEFT, RIGHT};
    MoveDirection moveDir;

    float startPosY;
    float degAngle = 0f;

    public void Init(Vector2 position, float speed, float moveHeight)
    {
        cachedTransform.position = position;
        this.speed = speed;
        this.moveHeight = moveHeight;
    }

	void Awake () 
    {
        cachedTransform = base.transform;
        startPosY = cachedTransform.position.y;
        moveDir = (Random.Range(0, 2) == 0) ? MoveDirection.LEFT : MoveDirection.RIGHT;
	}
	
	void Update () 
    {
        if(moveDir == MoveDirection.LEFT)
        {
            cachedTransform.Translate(Vector2.left * speed);
        }
        else if (moveDir == MoveDirection.RIGHT)
        {
            cachedTransform.Translate(Vector2.right * speed);
        }
        else
        {
            Debug.Assert(false, "moveDir변수에 예상하지 못한 값 발견");
        }

        float posY = Mathf.Sin(degAngle * Mathf.Deg2Rad) * moveHeight + startPosY;
        cachedTransform.position.Set(cachedTransform.position.x, posY, cachedTransform.position.z);
	}
}
