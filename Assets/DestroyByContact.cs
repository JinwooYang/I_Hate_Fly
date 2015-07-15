using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Fly"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
