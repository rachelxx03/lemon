
using UnityEngine;
using UnityEngine.UI;

public class GUIControl : MonoBehaviour
{
    public GameObject tracnghiem;
    public GameObject cothebanchuabiet;
    public GameObject lienhe;
    public GameObject menu, back;
    public Button tracnghiemButton, cothebanchuabietButton, lienheButton;
    public GameObject currentObject;
    private void Start()
    {

        tracnghiem = transform.GetChild(1).GetChild(0).gameObject;
        cothebanchuabiet = transform.GetChild(1).GetChild(1).gameObject;
        lienhe = transform.GetChild(1).GetChild(2).gameObject;
        tracnghiemButton = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Button>();
        cothebanchuabietButton = transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Button>();
        lienheButton=  transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<Button>();
        menu = transform.GetChild(0).gameObject;
        back = transform.GetChild(2).gameObject;
        tracnghiemButton.onClick.AddListener(TracNghiemOnClick);
        cothebanchuabietButton.onClick.AddListener(CoTheBanChuaBietOnClick);
        lienheButton.onClick.AddListener(LienHeOnClick);
        back.GetComponent<Button>().onClick.AddListener(BackOnClick);

    }
    public void TracNghiemOnClick()
    {
        tracnghiem.SetActive(true);
        menu.SetActive(false); 
        back.SetActive(true);
        currentObject=tracnghiem;
    }
    public void CoTheBanChuaBietOnClick()
    {
        cothebanchuabiet.SetActive(true);
        menu.SetActive(false);
        back.SetActive(true);
        currentObject = cothebanchuabiet;
    }
    public void LienHeOnClick()
    {
        lienhe.SetActive(true);
        menu.SetActive(false);
        back.SetActive(true);
        currentObject=lienhe;
       
    }
    public void BackOnClick()
    {
        currentObject.SetActive(false);
        menu.SetActive(true);
        back.SetActive(false);
    }
    private void OnDisable()
    {
        if(currentObject!=null)
        currentObject.SetActive(false);
        back.SetActive(false);
        menu.SetActive(true);
    }
}
