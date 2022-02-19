using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/SceneControllerReference")]
public class SceneControllerReference : Reference<SceneController>
{
    public void LoadSceneByName(string name)
    {
        Instance?.LoadSceneByName(name);
    }

    public void LoadCurrentScene()
    {
        Instance?.LoadCurrentScene();
    }
}
