using UnityEngine;
using System.Collections;

public class ScaleTo : Action 
{
    public float _Duration;
    public Vector3 _StartScale, _TargetScale;

    private Vector3 _DeltaScale;

    public ScaleTo(float duration, Vector3 startScale, Vector3 targetScale)
    {
        Init(duration, startScale, targetScale);
    }

    public void Init(float duration, Vector3 startScale, Vector3 targetScale)
    {
        _Duration = duration;
        _StartScale = startScale;
        _TargetScale = targetScale;
    }

	// Use this for initialization
	void Start () 
    {
        transform.localScale = _StartScale;
        _DeltaScale = (_TargetScale - _StartScale) / (_Duration * 60.0f);
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.localScale += _DeltaScale * Time.deltaTime * 60.0f;

        Vector3 curScale = transform.localScale;

        if(_StartScale.x <= _TargetScale.x && curScale.x >= _TargetScale.x ||
            _StartScale.x > _TargetScale.x && curScale.x < _TargetScale.x)
        {
            curScale.x = _TargetScale.x;
        }
        if (_StartScale.y <= _TargetScale.y && curScale.y >= _TargetScale.y ||
            _StartScale.y > _TargetScale.y && curScale.y < _TargetScale.y)
        {
            curScale.y = _TargetScale.y;
        }
        if (_StartScale.z <= _TargetScale.z && curScale.z >= _TargetScale.z ||
            _StartScale.z > _TargetScale.z && curScale.z < _TargetScale.z)
        {
            curScale.z = _TargetScale.z;
        }

        transform.localScale = curScale;

        if(curScale == _TargetScale)
        {
            Destroy(this);
        }
	}

    public override string GetClassName()
    {
        return "ScaleTo";
    }
}
