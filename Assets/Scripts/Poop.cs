using UnityEngine;
using System.Collections;

public class Poop : MonoBehaviour 
{
    private Actor _Actor = null;

    private Vector2 _OrgPos, _OrgScale;

	// Use this for initialization
	void Start () 
    {
        _Actor = GetComponent<Actor>();

        _OrgPos = transform.position;
        transform.position = new Vector2(transform.position.x, 1040.0f);

        _OrgScale = transform.localScale;
        transform.localScale = new Vector2(0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void RunPoopAction()
    {
        Action moveTo = new MoveTo(0.5f, _OrgPos);
        _Actor.RunAction(moveTo);

        Action scaleTo = new ScaleTo(0.5f, _OrgScale);
        _Actor.RunAction(scaleTo);
    }
}
