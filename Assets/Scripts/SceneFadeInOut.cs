using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour 
{
    public bool _FadeOut;
    public float _Duration;
    public string _ChangeSceneName;

    private SpriteRenderer _SprRenderer;
    private Actor _Actor;

	// Use this for initialization
	void Start () 
    {
        _SprRenderer = GetComponent<SpriteRenderer>();
        _Actor = GetComponent<Actor>();

	    if(_FadeOut)
        {
            _SprRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            _Actor.RunAction(new TintTo(_Duration, new Color(1.0f, 1.0f, 1.0f, 1.0f)));
            Invoke("ChangeScene", _Duration);
        }
        else
        {
            _SprRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            _Actor.RunAction(new TintTo(_Duration, new Color(1.0f, 1.0f, 1.0f, 0.0f)));
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    void ChangeScene()
    {
        Application.LoadLevel(_ChangeSceneName);
    }
}
