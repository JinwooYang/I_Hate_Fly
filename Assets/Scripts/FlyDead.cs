using UnityEngine;
using System.Collections;

public class FlyDead : MonoBehaviour 
{
    public float _FallSpeed;
    
    private new Transform transform;
    
    // Use this for initialization
	void Start () 
    {
        transform = base.transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(new Vector2(0.0f, -_FallSpeed));
	}
}
