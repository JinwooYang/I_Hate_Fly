using UnityEngine;
using System.Collections;

public class SinMove : Action 
{
    public float _Radius, _DeltaDegAngle;

    private float _OrgPosY;
    private float _CurAngle = 0.0f;

    public SinMove(float radius, float deltaAngle)
    {
        _Radius = radius;
        _DeltaDegAngle = deltaAngle;
    }

	protected override void OnActionStart(Actor actor) 
    {
        _OrgPosY = actor.transform.position.y;
	}
	
	// Update is called once per frame
    protected override void OnActionUpdate(Actor actor) 
    {
        float posY = _OrgPosY + Mathf.Sin(Mathf.Deg2Rad * _CurAngle) * _Radius;

        actor.transform.position = new Vector2(actor.transform.position.x, posY);

        _CurAngle += _DeltaDegAngle;
        if(_CurAngle > 360.0f)
        {
            _CurAngle -= 360.0f;
        }
	}
}
