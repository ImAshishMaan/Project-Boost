using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip crashAudio;

    AudioSource audioSource;
    
    bool isTransitioning = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning){ return; }

        switch(other.gameObject.tag)
        {
            case "Friendly":
                print("This is friendly");
                break;

            case "Finish":
                print("Congrates! You Won");
                StartSuccessSequence();
                break;

            default:
                print("Sorry, you blew up");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);
        // todo add particle effect upon success

        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);
        // todo add particle effect upon crash

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayTime);
    }
    void ReloadLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
