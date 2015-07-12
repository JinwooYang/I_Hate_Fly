using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour 
{
    public Animator gameStartAnim;

    Animator anim;

	void Awake () 
    {
	    anim = GetComponent<Animator>();
	}
	
	void RunUpAndDownAnim () 
    {
        anim.SetTrigger("RunUpAndDown");
	}

    void OnMouseDown()
    {
        gameStartAnim.SetTrigger("GameStart");
    }
}
