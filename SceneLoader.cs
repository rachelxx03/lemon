using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Text text;
    public Text waring;
    // Start is called before the first frame update
    public void Start()
    {
        if(SystemInfo.graphicsDeviceVersion.Equals("OpenGL ES 2.0"))
        {
            waring.gameObject.SetActive(true);
        }
        else
        { 
            
            waring.gameObject.SetActive(true);
            waring.text ="This device running on "+ SystemInfo.graphicsDeviceVersion;
            waring.color = Color.white;
        }

    }
    public void LoadScene(GameObject obj)
    {
        
        obj.SetActive(false);   
        text.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }
  
    public void Cancel()
    {
        Application.Quit();
    }
}
