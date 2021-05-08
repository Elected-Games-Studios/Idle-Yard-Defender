using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    public void LoadthisScene()
    {
        SceneManager.LoadScene(2);
    }
}
