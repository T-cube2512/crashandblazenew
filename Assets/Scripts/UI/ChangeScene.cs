using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneID;
    public void MoveToScene()
    {
        SceneManager.LoadScene(sceneID);
    }
}