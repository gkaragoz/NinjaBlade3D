using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject failPanel;
    public GameObject succesPanel;

    int _currentSceneIndex;

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OpenFailPanel()
    {
        failPanel.SetActive(true);
    }
    public void CloseFailPanel()
    {
        failPanel.SetActive(false);

    }

    public void OpenSuccesPanel()
    {
        succesPanel.SetActive(true);

    }

    public void CloseSuccesPanel()
    {
        succesPanel.SetActive(false);

    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

}
