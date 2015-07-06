using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDialog : MonoBehaviour 
{
    public int _Score;

	// Use this for initialization
	void Start () 
    {
        Text scoreText = GameObject.Find("ScoreDialogText").GetComponent<Text>();
        scoreText.text = "" + _Score;

        RunBlackImgAction();
        RunDialogAction();
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    void RunBlackImgAction()
    {
        Actor actor = GameObject.Find("black").GetComponent<Actor>();

        SpriteRenderer sprRenderer = this.transform.FindChild("black").GetComponent<SpriteRenderer>();

        Color blackOrgColor = sprRenderer.color;
        sprRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        actor.RunAction(new TintTo(1.0f, blackOrgColor));
    }


    void RunDialogAction()
    {
        Actor actor = GameObject.Find("Score Dialog").GetComponent<Actor>();

        Vector2 dialogOrgScale = actor.transform.localScale;
        actor.transform.localScale = new Vector2(0.0f, 0.0f);
        actor.RunAction(new Sequence( new DelayTime(1.5f), new ScaleTo(1.0f, dialogOrgScale)));
    }
}
