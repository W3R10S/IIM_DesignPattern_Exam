using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;
    [SerializeField] EntityBlock _block;
    [SerializeField]DetectObject _detectObject;
    ICatchable _item;

    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;
    [SerializeField] InputActionReference _blockButton;
    [SerializeField] InputActionReference _interactButton;

    Coroutine MovementTracking { get; set; }

    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);

    private void Start()
    {
        // binding
        _fireButton.action.started += FireInput;

        _blockButton.action.started += BlockInput;
        _blockButton.action.canceled += BlockInput;

        _interactButton.action.started += InteractInput;
        _interactButton.action.canceled += InteractInput;

        _moveJoystick.action.started += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;

        // Init variables
        _block.BlockBullet(false);
        _fire.canFire = true;
    }

    private void OnDestroy()
    {
        _fireButton.action.started -= FireInput;

        _blockButton.action.started -= BlockInput;
        _blockButton.action.canceled -= BlockInput;

        _interactButton.action.started -= InteractInput;
        _interactButton.action.canceled -= InteractInput;

        _moveJoystick.action.started -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        float fire = obj.ReadValue<float>();
        if(fire==1 && _fire.canFire)
        {
            _fire.FireBullet(2);
        }
    }

    private void BlockInput(InputAction.CallbackContext obj)
    {
        float block = obj.ReadValue<float>();
        if(block==1)
        {
            _block.BlockBullet(true);
            _fire.canFire = false;
        } else
        {
            _block.BlockBullet(false);
            _fire.canFire = true;
        }
    }

    private void InteractInput(InputAction.CallbackContext obj)
    {
        if(_detectObject.item == null)
        {
            return;
        }
        if(_detectObject.item.GetComponentInParent<ICatchable>() == null)
        {
            return;
        }

        _item = _detectObject.item.GetComponentInParent<ICatchable>();
        float interact = obj.ReadValue<float>();
        if(interact==1)
        {
            _item.Use(FindObjectOfType<PlayerEntity>());
        }
    }
}
