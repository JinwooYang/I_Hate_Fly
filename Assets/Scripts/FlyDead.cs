using UnityEngine;
using System.Collections;

public class FlyDead : MonoBehaviour 
{
    public float _FallSpeed;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(new Vector2(0.0f, -_FallSpeed));
	}
}
