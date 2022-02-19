using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectObject : MonoBehaviour
{
    [HideInInspector] public GameObject item;
    public Transform dropPoint;
    public UnityAction<GameObject> OnDropItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<ICatchable>() != null)
        {
            if (item == null)
            {
                item = collision.gameObject;
                item.transform.parent.position = Vector3.zero;
                item.transform.parent.transform.SetParent(transform, false);
            } else
            {
                item.transform.parent.transform.parent = null;
                OnDropItem?.Invoke(item);
                item = collision.gameObject;
                item.transform.parent.position = Vector3.zero;
                item.transform.parent.transform.SetParent(transform, false);
            }
        }
    }

    private void Start()
    {
        OnDropItem += OnDisableTemporarly;
    }

    private void OnDestroy()
    {
        OnDropItem -= OnDisableTemporarly;
    }

    private void OnDisableTemporarly(GameObject obj)
    {
        StartCoroutine(DisableTemporarly(obj));
    }

    private IEnumerator DisableTemporarly(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(2f);
        obj.SetActive(true);
    }
}
