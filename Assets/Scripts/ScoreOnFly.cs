using UnityEngine;
using System.Collections;

public class ScoreOnFly : MonoBehaviour 
{
    private Actor _Actor;

	// Use this for initialization
	void Start () 
    {
        _Actor = GetComponent<Actor>();

        transform.localScale = new Vector2(0.0f, 0.0f);

        Action scaleUp = new ScaleTo(0.25f, new Vector2(1.0f, 1.0f));
        Action scaleDown = new ScaleTo(0.25f, new Vector2(0.0f, 0.0f));
        Action seq = new Sequence(scaleUp, new DelayTime(0.25f), scaleDown, new SelfRemove());

        _Actor.RunAction(seq);
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
}
