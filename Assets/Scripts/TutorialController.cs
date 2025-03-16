using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("navigationTestScene");
    }
}
