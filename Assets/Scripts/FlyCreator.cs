using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//class FlyInstance
//{
//    Fly fly;
//    bool reusable;

//    public FlyInstance(Fly fly, bool reusable)
//    {
//        this.fly = fly;
//        this.reusable = reusable;
//    }

//    public bool IsReusable()
//    {
//        return reusable;
//    }
//}


public class FlyCreator : MonoBehaviour 
{
    public Fly flyTemplate;

    //최초 생성해 둘 파리의 갯수
    public int beginCreateNum;

    public float delay;

    public float createProbability;

    public Vector2 spawnMin, spawnMax;

    public float minSpeed, maxSpeed;
    public float minScale, maxScale;
    public float minMoveHeight, maxMoveHeight;

    List<Fly> flyPool = new List<Fly>();

    float timer = 0f;


	void Awake () 
    {
        flyPool.Capacity = beginCreateNum;

        for (int i = 0; i < beginCreateNum; ++i)
        {
            AddFlyInstanceInPool();
        }
	}
	

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            if (Random.Range(0f, 100f) < createProbability)
            {
                timer = 0f;

                Fly fly = FindNotActiveFlyInstance();

                fly = (fly != null) ? fly : AddFlyInstanceInPool();

                FlyInitAndEnable(fly);
            }
        }
    }


    Fly FindNotActiveFlyInstance()
    {
        for (int i = 0; i < flyPool.Count; ++i)
        {
            if(!flyPool[i].gameObject.activeInHierarchy)
            {
                return flyPool[i];
            }
        }
        return null;
    }


    Fly AddFlyInstanceInPool()
    {
        Fly fly = Instantiate(flyTemplate);
        fly.gameObject.SetActive(false);
        flyPool.Add(fly);

        return fly;
    }


    void FlyInitAndEnable(Fly fly)
    {
        float posX;
        MoveDirection moveDir;

        if (Random.Range(0, 2) == 0)
        {
            moveDir = MoveDirection.LEFT;
            posX = spawnMax.x;
        }
        else
        {
            moveDir = MoveDirection.RIGHT;
            posX = spawnMin.x;
        }

        float posY = Random.Range(spawnMin.y, spawnMax.y);
        float scale = Random.Range(minScale, maxScale);
        float speed = Random.Range(minSpeed, maxSpeed);
        float moveHeight = Random.Range(minMoveHeight, maxMoveHeight);

        fly.Init(posX, posY, scale, speed, moveHeight, moveDir);
    }
}
