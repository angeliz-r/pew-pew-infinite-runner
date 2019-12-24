using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySaveManager : MonoBehaviour
{
    public PlayerData player;
    public SaveManager saveManager;
    public bool paused, save, load, canSave;
    private void Awake()
    {
        save = true;
        load = true;
        canSave = true;
    }
    private void Start()
    {
        Application.runInBackground = true;
    }

    private void Update()
    {
        if (paused)
        {
            if (save)
            {
                load = true;
                canSave = false;
                save = false;
            }
        }
        else if (!paused)
        {
            if (canSave)
                saveManager.Save(GameManager.instance.CopyToSaveData());
            if (load)
            {
                canSave = true;
                save = true;
                load = false;
            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        paused = !focus;
    }
}
