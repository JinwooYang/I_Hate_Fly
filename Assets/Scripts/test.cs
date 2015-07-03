using UnityEngine;
using System.Collections;

public class test : MonoBehaviour 
{
    private new Transform transform;
    private ActionManager _ActionManager;
    private Vector3 startPos;

	// Use this for initialization
	void Start () 
    {
        transform = base.transform;
        startPos = transform.position;

        _ActionManager = ActionManager.GetInstance();

        _ActionManager.AddAction(Move);
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    private void Move()
    {
        transform.Translate(Vector3.right);

        if(transform.position.x > startPos.x + 300f)
        {
            Vector3 pos = transform.position;
            pos.x = startPos.x + 300f;
            transform.position = pos;
            _ActionManager.DeleteAction(Move);
        }
    }
}
