using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerReferenceSetter : MonoBehaviour
{
    [SerializeField] SceneController _sceneController;
    [SerializeField] SceneControllerReference _sceneControllerRef;

    void Awake()
    {
        (_sceneControllerRef as IReferenceSetter<SceneController>).SetInstance(_sceneController);
    }
}
