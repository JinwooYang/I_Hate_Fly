using UnityEngine;
using System.Collections;

public class FlyCreator : MonoBehaviour 
{
    public Fly _Fly;

    public float _CreateDelayTime;
    public int _CreatePercent;

    public float _CreateMinX, _CreateMaxX;
    public float _CreateMinY, _CreateMaxY;

    private new Transform transform;

	// Use this for initialization
	void Start () 
    {
        transform = base.transform;

        StartCoroutine("FlyCreate");
    }
	
	// Update is called once per frame
	void Update () 
    {
	}


    IEnumerator FlyCreate()
    {
        yield return new WaitForSeconds(_CreateDelayTime);

        while(true)
        {
            if (Random.Range(0, 100) < _CreatePercent)
            {
                Vector2 pos;
                if (Random.Range(0, 2) == 0)
                {
                    pos = new Vector2(_CreateMinX, Random.Range(_CreateMinY, _CreateMaxY));
                    Fly fly = Instantiate(_Fly, pos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as Fly;
                    fly.SetMoveRight(true);
                }
                else
                {
                    pos = new Vector2(_CreateMaxX, Random.Range(_CreateMinY, _CreateMaxY));
                    Fly fly = Instantiate(_Fly, pos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as Fly;
                    fly.SetMoveRight(false);
                }

                yield return new WaitForSeconds(_CreateDelayTime);
            }
        }
    }
}
