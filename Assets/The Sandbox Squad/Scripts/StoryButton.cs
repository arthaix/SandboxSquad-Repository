using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryButton : MonoBehaviour
{
    [SerializeField] private Renderer storyScreen;
    [SerializeField] private Material pureHate;
    [SerializeField] private Material pureDeath;
    [SerializeField] private Material pureLight;

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
        if (storyNum < 4)
        {
            switch (storyNum)
            {
                case 1:
                    storyScreen.material = pureHate;
                    break;
                case 2:
                    storyScreen.material = pureDeath;
                    break;
                case 3:
                    storyScreen.material = pureLight;
                    break;
            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
