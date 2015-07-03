using UnityEngine;
using System.Collections;

public class TitleSceneManager : MonoBehaviour 
{
    public Poop _Poop;
    public Title _Title;
    public GameStartButton _GameStartButton;

	// Use this for initialization
	void Start () 
    {
        Invoke("RunPoopAction", 0.5f);
        Invoke("RunTitleAction", 1.0f);
        Invoke("RunGameStartButtonAction", 1.2f);

        ActionManager.GetInstance();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}


    void RunPoopAction()
    {
        _Poop.RunPoopAction();
    }


    void RunTitleAction()
    {
        _Title.RunTitleAction();
    }


    void RunGameStartButtonAction()
    {
        _GameStartButton.RunGameStartButtonAction();
    }
}
