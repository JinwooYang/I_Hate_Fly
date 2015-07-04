using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionManager : MonoBehaviour 
{
    private static ActionManager _Instance = null;

    public delegate void ActionFunc();
    private ActionFunc _Handler;

    private ActionManager()
    {

    }

	// Use this for initialization
    //void Start () 
    //{
    //}
	
	// Update is called once per frame
	void Update () 
    {
        if(_Handler != null)
            _Handler();
	}

    public static ActionManager GetInstance()
    {
        if(_Instance == null)
        {
            _Instance = new GameObject().AddComponent<ActionManager>();
            _Instance.name = typeof(ActionManager).ToString();
            DontDestroyOnLoad(_Instance);
        }

        return _Instance;
    }

    public void AddAction(ActionFunc func)
    {
        Debug.Assert(func != null);
        _Handler += func;
    }

    public void DeleteAction(ActionFunc func)
    {
        Debug.Assert(func != null);
        Debug.Assert(_Handler != null);

        _Handler -= func;
    }
}
