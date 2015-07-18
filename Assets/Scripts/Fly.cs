using UnityEngine;
using System.Collections;

public enum MoveDirection { LEFT, RIGHT };

public class Fly : MonoBehaviour
{
    public float speed;
    public float moveHeight;
    public float fallSpeed = 8f;

    MoveDirection moveDir;

    Transform cachedTransform;

    float startPosY;
    float degAngle = 0f;

    Animator anim;

    bool dead = false;

    PlaySceneManager playSceneMgr;

    public void Init(float posX, float posY, float newScale, float newSpeed, float newMoveHeight, MoveDirection newDirection)
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
            tempScale.x = -newScale;
            tempScale.y = newScale;
            cachedTransform.localScale = tempScale;
        }
        else
        {
            Vector3 tempScale = cachedTransform.localScale;
            tempScale.x = newScale;
            tempScale.y = newScale;
            cachedTransform.localScale = tempScale;
        }

        dead = false;

        gameObject.SetActive(true);
    }


    void Awake()
    {
        cachedTransform = base.transform;
        anim = GetComponent<Animator>();
        playSceneMgr = Object.FindObjectOfType<PlaySceneManager>();
    }


    void Update()
    {
        if (!dead)
        {
            switch (moveDir)
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

            if (degAngle > 360f)
            {
                degAngle -= 360f;
            }
        }
        else
        {
            cachedTransform.Translate(Vector3.down * fallSpeed);
        }
    }


    void OnMouseDown()
    {
        if (!playSceneMgr.IsGameOver())
        {
            dead = true;
            anim.SetBool("IsDead", true);
            playSceneMgr.AddScore(10);
        }
    }
}
 