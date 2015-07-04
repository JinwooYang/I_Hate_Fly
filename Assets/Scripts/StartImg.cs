using UnityEngine;
using System.Collections;

public class StartImg : MonoBehaviour 
{
    private new Transform transform;

    private Actor _Actor;

    private Vector2 _OrgPos;

    private SpriteRenderer _SprRenderer;

	// Use this for initialization
	void Start () 
    {
        transform = base.transform;

	    _Actor = GetComponent<Actor>();
        _SprRenderer = GetComponent<SpriteRenderer>();

        _SprRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        _OrgPos = transform.position;

        transform.position = new Vector2(_OrgPos.x - 150.0f, _OrgPos.y);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}


    public void RunStartImgAction()
    {
        Action leftToCenter = new MoveTo(0.25f, _OrgPos);
        Action moveDelay = new DelayTime(0.25f);
        Action centerToRight = new MoveTo(0.25f, new Vector2(_OrgPos.x + 150.0f, _OrgPos.y));

        Action moveSeq = new Sequence( leftToCenter, moveDelay, centerToRight);

        _Actor.RunAction(moveSeq);

        Action fadeIn = new TintTo(0.25f, new Color(1.0f, 1.0f, 1.0f, 1.0f));
        Action fadeDelay = new DelayTime(0.25f);
        Action fadeOut = new TintTo(0.25f, new Color(1.0f, 1.0f, 1.0f, 0.0f));

        Action fadeSeq = new Sequence(fadeIn, fadeDelay, fadeOut);

        _Actor.RunAction(fadeSeq);
    }
}
