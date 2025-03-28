using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarter: MonoBehaviour
{

    public void OnLevel1StartClick()
    {
        SceneManager.LoadScene(1);
    }
 
    public void OnLevel2StartClick()
    {
        SceneManager.LoadScene(2);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
