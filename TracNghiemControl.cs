using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracNghiemControl : MonoBehaviour
{
    public bool a;
    public bool b;
    public bool c;
    public Sprite rightIcon, wrongIcon;
    public GameObject _a, _b,_c;
    // Start is called before the first frame update
    void Start()
    {
        _a = transform.GetChild(1).GetChild(0).gameObject;
        _b = transform.GetChild(1).GetChild(1).gameObject;
        _c = transform.GetChild(1).GetChild(2).gameObject;
        _a.GetComponent<Button>().onClick.AddListener(delegate { Check(1); });
        _b.GetComponent<Button>().onClick.AddListener(delegate { Check(2); });
        _c.GetComponent<Button>().onClick.AddListener(delegate { Check(3); });
        _a.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
        _a.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.clear;
        _b.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
        _b.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.clear;
        _c.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
        _c.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.clear;
    }

  void Check(int value)
    {
        _a.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = a ? rightIcon : wrongIcon;
        _a.transform.GetChild(1).gameObject.GetComponent<Image>().color = a ? Color.green : Color.red;
        _b.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = b ? rightIcon : wrongIcon;
        _b.transform.GetChild(1).gameObject.GetComponent<Image>().color = b ? Color.green : Color.red;
        _c.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = c ? rightIcon : wrongIcon;
        _c.transform.GetChild(1).gameObject.GetComponent<Image>().color = c ? Color.green : Color.red;
        switch (value)
        {
            case 1:
                if (a) { }
                break;
            case 2:
                if (b) { }
                break;
            case 3:if (c)
                { 
                } break;
               
        }
    }
 
    private void OnDisable()
    {
        _a.transform.GetChild(1).gameObject.GetComponent<Image>().sprite =null;
        _a.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.clear;
        _b.transform.GetChild(1).gameObject.GetComponent<Image>().sprite =null;
        _b.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.clear;
        _c.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
        _c.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.clear;
    }

}
