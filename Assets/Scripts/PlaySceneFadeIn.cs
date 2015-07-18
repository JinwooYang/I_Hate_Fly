using UnityEngine;
using System.Collections;

public class PlaySceneFadeIn : MonoBehaviour 
{
    public Animator startImgAnim;
    public PlaySceneManager playSceneMgr;

    //Animator anim;

	void Awake () 
    {
        //anim = GetComponent<Animator>();

	}
	
	void RunStartImgAnim() 
    {
        startImgAnim.SetTrigger("RunStartImgAnim");
        playSceneMgr.StartTimer();
	}
}
