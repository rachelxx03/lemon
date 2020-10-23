

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public struct SceneObject
{
    public string url;
    public string metafile_url;
    public string Name;
}
[System.Serializable]
public struct ImageTargetObject
{
    public GameObject obj;
    public string name;
};
public class LoadScene : MonoBehaviour
{
    public string dataPath;
    public AssetBundle bundle;
    public SceneObject rootobject;
    public List<ImageTargetObject> imagetargets;
    public long len;
    public long currentSize;
    public Text txt;
    public GameObject gamePlay;
    public GameObject audioRes, arcamera, rootmodel;
    string result;
    // Use this for initialization
    void Awake()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "DownloadedAssetBundles");
    }

    void Start()
    {


        if (!File.Exists(Path.Combine(dataPath, rootobject.Name + ".unity3d")))
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(rootobject.url);
            req.Method = "HEAD";

            using (HttpWebResponse resp = (HttpWebResponse)(req.GetResponse()))
            {
                len = resp.ContentLength;

            }

            StartCoroutine(DownloadingAssetBundles());
        }
        else
        {
            StartCoroutine(DownloadMetaFile("metafile"));

        }



    }
    private IEnumerator DownloadMetaFile(string name)
    {
        UnityWebRequest www = UnityWebRequest.Get(rootobject.metafile_url);
        DownloadHandler handle = www.downloadHandler; 
        //Send Request and wait
        yield return www.SendWebRequest();
        SaveDataToDisk(name, handle.data);
        AssetBundleCreateRequest requestbundle = AssetBundle.LoadFromFileAsync(Path.Combine(dataPath, name + ".unity3d"));
        AssetBundle metaBundle = requestbundle.assetBundle;
        TextAsset metatxt = metaBundle.LoadAsset("meta.txt") as TextAsset;
        string lastModified = metatxt.text;
        System.DateTime fileDownloadDate = System.IO.File.GetLastWriteTime(Path.Combine(dataPath, rootobject.Name + ".unity3d"));
        System.DateTime updateDate = System.DateTime.Parse(lastModified.Trim());
        if (System.DateTime.Compare(fileDownloadDate, updateDate) <= 0)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(rootobject.url);
            req.Method = "HEAD";

            using (HttpWebResponse resp = (HttpWebResponse)(req.GetResponse()))
            {
                len = resp.ContentLength;

            }
            StartCoroutine(DownloadingAssetBundles());

        }
        else
        {

            requestbundle = AssetBundle.LoadFromFileAsync(Path.Combine(dataPath, rootobject.Name + ".unity3d"));
            bundle = requestbundle.assetBundle;
            LoadSceneObj();
            txt.gameObject.transform.parent.gameObject.SetActive(false);
            audioRes.SetActive(true);
            arcamera.SetActive(true);
            rootmodel.SetActive(true);
            gamePlay.GetComponent<GameStart>().enabled = true;
        }
    }
    private IEnumerator DownloadingAssetBundles()
    {
        UnityWebRequest www = UnityWebRequest.Get(rootobject.url);
        DownloadHandler handle = www.downloadHandler;
        StartCoroutine(ShowProgress(www, 0));
        //Send Request and wait
        yield return www.SendWebRequest();
        SaveDataToDisk(rootobject.Name, handle.data);
        AssetBundleCreateRequest requestbundle = AssetBundle.LoadFromFileAsync(Path.Combine(dataPath, rootobject.Name + ".unity3d"));


        // bundle.LoadAllAssets();
        //Load an asset from the loaded bundle
        bundle = requestbundle.assetBundle;
        LoadSceneObj();
        txt.gameObject.transform.parent.gameObject.SetActive(false);
        audioRes.SetActive(true);
        arcamera.SetActive(true);
        rootmodel.SetActive(true);
        gamePlay.GetComponent<GameStart>().enabled = true;
    }
    private void SaveDataToDisk(string name, byte[] data)
    {

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
        File.WriteAllBytes(Path.Combine(dataPath, name + ".unity3d"), data);

    }

    // Update is called once per frame
    private IEnumerator ShowProgress(UnityWebRequest www, long temp)
    {
        while (!www.isDone)
        {

            currentSize = temp + (long)www.downloadedBytes;
            long Percentageused = (long)((float)currentSize / len * 100);
            txt.text = "Please wait for downloading..." + Percentageused.ToString() + "%";
            yield return new WaitForSeconds(.01f);
        }


    }
    public void LoadSceneObj()
    {
        for (int i = 0; i < imagetargets.Count; i++)
        {
            GameObject obj = bundle.LoadAsset<GameObject>(imagetargets[i].name);
            GameObject temp = Instantiate(obj, imagetargets[i].obj.transform);
            temp.SetActive(false);
        }
    }
}
