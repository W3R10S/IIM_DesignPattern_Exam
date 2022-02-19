using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDoorDetector : MonoBehaviour
{
    public GameObject door;
    public Vector3 doorPosition;
    public event UnityAction<Vector3> OnExplosion;
    public UnityEvent _onExplosionSound;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            if (collision.gameObject.transform.parent.Equals(door.transform))
            {
                doorPosition = collision.gameObject.transform.parent.transform.position;
                OnExplosion?.Invoke(doorPosition);
                _onExplosionSound?.Invoke();
                door.SetActive(false);
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
