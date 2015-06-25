using UnityEngine;
using System.Collections;

public class TitleAnimation : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        RunTitleAnimation();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    public void RunTitleAnimation()
    {
        ScaleTo scaleTo = gameObject.AddComponent<ScaleTo>();
        scaleTo.Init(0.4f, new Vector3(0, 0, 0), new Vector3(100, 100, 0));
    }
}
