using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public class Sequence : Action 
//{
//    public List<Action> _InnerAction;

//    private int curActionIndex = 0;

//    public void Init(params Action[] args)
//    {
//        for (int i = 0; i < args.Length; ++i)
//        {
//            _InnerAction.Add(args[i]);
//        }
//    }

//    // Use this for initialization
//    void Start () 
//    {
//        gameObject.AddComponent(_InnerAction[curActionIndex].GetType());
//    }
	
//    // Update is called once per frame
//    void Update () 
//    {
//        if(_InnerAction[curActionIndex] == null)
//        {
//            if(++curActionIndex < _InnerAction.Count)
//            {
//                gameObject.AddComponent(_InnerAction[curActionIndex].GetType());
//            }
//            else
//            {
//                Destroy(this);
//            }
//        }
//    }


//    public override string GetClassName()
//    {
//        return "Sequence";
//    }
//}
