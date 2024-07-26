using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{

    [SerializeField] GameObject _Credits;
    [SerializeField] PlayerMovement _PlayerMovement;

    public void OpenCredits()
    {
        if (!_Credits.activeSelf)
        {
            _Credits.SetActive(true);

        }

    }
    public void CloseCredits()
    {
        if (_Credits.activeSelf)
        {
            _Credits.SetActive(false);

        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame(string SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }
}
