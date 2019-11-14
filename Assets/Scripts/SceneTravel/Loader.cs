using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader
{

    /*TO TRAVEL BETWEEN SCENES, insert this code:
        Loader.Load(Loader.Scene.SceneName);
        MAKE SURE SceneName is in the ENUM BELOW!
    */

    private class LoadingMonoBehaviour : MonoBehaviour{ }


    public enum Scene
    {
        MainMenu,
        Game,
        LoadScene
    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene scene)
    {  
        //loader callback will load target scene
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };
        //load the loading scene
        SceneManager.LoadScene(Scene.LoadScene.ToString());
    }

    private static IEnumerator LoadSceneAsync (Scene scene)
    {
        yield return null;
        AsyncOperation loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        while (!loadingAsyncOperation.isDone)
        {
            yield return null; 
        }
    }

    public static float GetLoadingProgress()
    {
        if (loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        } else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

}
