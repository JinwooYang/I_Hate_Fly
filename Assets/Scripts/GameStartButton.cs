using UnityEngine;
using System.Collections;

public class GameStartButton : MonoBehaviour 
{
    public GameObject _FlyDead;

    public GameObject _SceneFadeOut;

    private Actor _Actor;

    private Vector2 _OrgPos;

    private new Transform transform;

	// Use this for initialization
	void Start () 
    {
        transform = base.transform;

	    _Actor = GetComponent<Actor>();
        _OrgPos = transform.position;

        transform.position = new Vector2(-80.0f, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}


    public void RunGameStartButtonAction()
    {
        Action moveTo = new MoveTo(0.5f, _OrgPos);
        Action sinMove = new SinMove(20.0f, 5.0f);

        Action seq = new Sequence(moveTo, sinMove);

        _Actor.RunAction(seq);
    }


    void OnMouseDown()
    {
        gameObject.SetActive(false);
        Instantiate(_FlyDead, transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        Instantiate(_SceneFadeOut, new Vector2(512.0f, 384.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
    }
}
