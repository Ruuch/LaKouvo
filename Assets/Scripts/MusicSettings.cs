using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSettings : MonoBehaviour
{
    public int musicSettingseihin;

    // Update is called once per frame
    public void MusicSettingsScreeniin()
    {
        SceneManager.LoadScene(musicSettingseihin);
    }
}
