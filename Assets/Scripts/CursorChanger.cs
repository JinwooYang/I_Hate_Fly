using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour 
{
    public Texture2D _CursorTexture;

	// Use this for initialization
	void Start () 
    {
        Cursor.SetCursor(_CursorTexture, new Vector2(_CursorTexture.width / 2, _CursorTexture.height / 2), CursorMode.ForceSoftware);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
