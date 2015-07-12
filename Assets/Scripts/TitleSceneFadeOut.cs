using UnityEngine;
using System.Collections;

public class GameStartAnimation : MonoBehaviour 
{
    Animator anim;

	void Awake () 
    {
        anim = GetComponent<Animator>();
	}
	
	void ChangeScene () 
    {
        Application.LoadLevel("PlayScene");
	}
}
