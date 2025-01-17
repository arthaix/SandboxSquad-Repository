using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryButton : MonoBehaviour
{
    [SerializeField] private Mesh storyScreen;

    private int storyNum = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTheScene()
    {
        storyNum++;
        if (storyNum < 3)
        {

        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
