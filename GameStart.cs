
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    Button start, exit;
    [SerializeField]
    GameObject mainMenu;
    public string name;
    // Start is called before the first frame update
    void Start()
    {

        mainMenu = transform.GetChild(0).gameObject;
        mainMenu.SetActive(true);
        start = mainMenu.transform.GetChild(0).gameObject.GetComponent<Button>();
        exit = mainMenu.transform.GetChild(1).gameObject.GetComponent<Button>();
        start.onClick.AddListener(StartOnClick);
        exit.onClick.AddListener(ExitOnClick); 

    }
    public void StartOnClick()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VuforiaMonoBehaviour>().enabled = true;
        mainMenu.SetActive(false);  
    }
    public void ExitOnClick()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void DoDial(string phone)
    {
    
    }
}
