using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour
{
    public void ChangeScene()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("tutorial");
    }

}