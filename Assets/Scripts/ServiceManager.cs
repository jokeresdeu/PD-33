using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceManager : MonoBehaviour
{
    #region Singelton
    public static ServiceManager Instanse;
    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
        else
            Destroy(gameObject);
    }
    #endregion 

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
