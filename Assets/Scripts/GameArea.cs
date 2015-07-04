using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour 
{
    public PlaySceneManager _PlaySceneManager;

    private new Transform transform;

	// Use this for initialization
	void Start () 
    {
        transform = base.transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Fly" || other.tag == "Fly_Dead")
        {
            Destroy(other.gameObject);

            if (other.tag == "Fly")
            {
                _PlaySceneManager.SubtractTime(1.0f);
            }
        }
    }
}
