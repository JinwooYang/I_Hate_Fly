using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour 
{
    private Actor _Actor = null;

	// Use this for initialization
	void Start () 
    {
        _Actor = GetComponent<Actor>();
        transform.localScale = new Vector2(0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    public void RunTitleAction()
    {
        Action seq = new Sequence
        (
            new ScaleTo(0.5f, new Vector2(100, 100)),
            new RepeatForever
            (
                new Sequence
                (
                    new ScaleTo(1.0f, new Vector2(105, 105)),
                    new ScaleTo(1.0f, new Vector2(100, 100))
                )
            )
        );

        _Actor.RunAction(seq);
    }
}
