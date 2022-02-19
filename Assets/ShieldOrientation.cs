using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrientation : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteReference;
    [SerializeField] Transform _rootTransform;
    [SerializeField] Vector2 _noFlipPosition;
    [SerializeField] Vector2 _flipPosition;

    private void LateUpdate()
    {
        _rootTransform.localPosition = _spriteReference.flipX ? _flipPosition : _noFlipPosition;
    }

}
