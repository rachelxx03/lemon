
using UnityEngine;
using UnityEngine.UI;

public class LienHeControl : MonoBehaviour
{
    public GameObject currentObj;
    public Button back;
    public GameObject menu;
    public void OnEnable()
    {

        if (back != null)
        {
          
            back.onClick.AddListener(OnBack);
      
        }
    }
    public void OpenLienHe(GameObject obj)
    {
        back.gameObject.SetActive(true);
        obj.SetActive(true);
        currentObj = obj;
        menu.SetActive(false); 
       
    }
    public void OnBack()
    {
        currentObj.SetActive(false);
        menu.SetActive(true);
        back.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
       if(back!=null)
        back.gameObject.SetActive(false);
    }
}
