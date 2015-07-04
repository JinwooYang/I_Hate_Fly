using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fly : MonoBehaviour 
{
    public FlyDead _FlyDead;
    public Text _ScoreOnFly;

    public float _MinSpeed, _MaxSpeed;
    public float _MinRadius, _MaxRadius;
    public float _MinScale, _MaxScale;

    private bool _MoveRight;
    private float _Speed;
    private float _Radius;
    private float _Scale;

    private Actor _Actor;

    private PlaySceneManager _PlaySceneManager;

    private new Transform transform;

	// Use this for initialization
	void Start () 
    {
        transform = base.transform;

        _PlaySceneManager = GameObject.Find("PlaySceneManager").GetComponent<PlaySceneManager>();

        _Actor = GetComponent<Actor>();
        _Speed = Random.Range(_MinSpeed, _MaxSpeed);
        _Radius = Random.Range(_MinRadius, _MaxRadius);
        _Scale = Random.Range(_MinScale, _MaxScale);

        Vector2 scaleVector = new Vector2(_Scale, _Scale);

        if(!_MoveRight)
        {
            _Speed = -_Speed;
            scaleVector.x = -scaleVector.x;
        }

        transform.localScale = scaleVector; 

        _Actor.RunAction(new SinMove(_Radius, 2.0f));
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(new Vector2(_Speed, 0.0f));
	}


    void OnMouseDown()
    {
        if(!_PlaySceneManager.IsGameOver())
        {
            const int score = 10;

            Destroy(this.gameObject);
        
            FlyDead flyDead = Instantiate(_FlyDead, transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as FlyDead;
            flyDead.gameObject.transform.localScale = transform.localScale;

            Text scoreOnFly = Instantiate(_ScoreOnFly, transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as Text;
            scoreOnFly.text = "+" + score;
            GameObject canvas = GameObject.Find("Canvas");
            scoreOnFly.transform.SetParent(canvas.transform);

            _PlaySceneManager.AddScore(score);
        }
    }


    public void SetMoveRight(bool moveRight)
    {
        _MoveRight = moveRight;
    }
}
