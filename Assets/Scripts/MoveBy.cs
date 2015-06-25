using UnityEngine;
using System.Collections;

public class MoveBy : Action 
{
    public float _Duration;
    public Vector3 _StartPos, _TargetPos;

    private Vector3 _DeltaPos;

    public MoveBy(float duration, Vector3 startPos, Vector3 tergetPos)
    {
        Init(duration, startPos, tergetPos);
    }

    public void Init(float duration, Vector3 startPos, Vector3 tergetPos)
    {
        _Duration = duration;
        _StartPos = startPos;
        _TargetPos = tergetPos;
    }

	// Use this for initialization
	void Start () 
    {
        transform.position = _StartPos;
        _DeltaPos = (_TargetPos - _StartPos) / (_Duration * 60.0f);
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.position += _DeltaPos * Time.deltaTime * 60.0f;

        Vector3 curPos = transform.position;

        if (_StartPos.x <= _TargetPos.x && curPos.x >= _TargetPos.x ||
            _StartPos.x > _TargetPos.x && curPos.x < _TargetPos.x)
        {
            curPos.x = _TargetPos.x;
        }
        if (_StartPos.y <= _TargetPos.y && curPos.y >= _TargetPos.y ||
            _StartPos.y > _TargetPos.y && curPos.y < _TargetPos.y)
        {
            curPos.y = _TargetPos.y;
        }
        if (_StartPos.z <= _TargetPos.z && curPos.z >= _TargetPos.z ||
            _StartPos.z > _TargetPos.z && curPos.z < _TargetPos.z)
        {
            curPos.z = _TargetPos.z;
        }

        transform.position = curPos;

        if (curPos == _TargetPos)
        {
            Destroy(this);
        }
	}


    public override string GetClassName()
    {
        return "MoveBy";
    }
}
