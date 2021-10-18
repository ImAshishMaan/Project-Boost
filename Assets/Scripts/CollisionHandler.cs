using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                print("This is friendly");
                break;
            case "Finish":
                print("Congrates! You Won");
                StartNextLevelSequence();
                break;
            case "Fuel":
                print("You got Fuel");
                break;
            default:
                print("Sorry, you blew up");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        Invoke("ReloadLevel", delayTime);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartNextLevelSequence()
    {
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
