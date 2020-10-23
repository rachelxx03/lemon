using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{

    public string url, urlMaterial;
    public string dataPath;

    private void Awake()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "DownloadedAssetBundles");
    }
    private void Start()
    {

        if (!File.Exists(Path.Combine(dataPath, "Material.unity3d")))
            StartCoroutine(DownloadingAssetBundles());
        else
        {
            AssetBundleCreateRequest requestbundle = AssetBundle.LoadFromFileAsync(Path.Combine(dataPath, "Material.unity3d"));

            // bundle.LoadAllAssets();
            //Load an asset from the loaded bundle
            AssetBundle bundle = requestbundle.assetBundle;
            bundle.LoadAllAssets();
        }


    }



    private IEnumerator DownloadingAssetBundles()
    {
        Debug.Log("StaticMesh downloading ");
        UnityWebRequest www = UnityWebRequest.Get(url);
        DownloadHandler handle = www.downloadHandler;
        StartCoroutine(ShowProgress(www));
        //Send Request and wait
        yield return www.SendWebRequest();
        SaveDataToDisk("StaticMesh", handle.data);

        Debug.Log("Material downloading ");
        www = UnityWebRequest.Get(urlMaterial);
        handle = www.downloadHandler;
        StartCoroutine(ShowProgress(www));
        yield return www.SendWebRequest();
        SaveDataToDisk("Material", handle.data);
        AssetBundleCreateRequest requestbundle = AssetBundle.LoadFromFileAsync(Path.Combine(dataPath, "Material.unity3d"));
        yield return requestbundle;
        // bundle.LoadAllAssets();
        //Load an asset from the loaded bundle
        AssetBundle bundle = requestbundle.assetBundle;
        bundle.LoadAllAssets();
    }

    private void SaveDataToDisk(string name, byte[] data)
    {

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
        File.WriteAllBytes(Path.Combine(dataPath, name + ".unity3d"), data);

    }

    public void Load(string name)
    {
        StartCoroutine(LoadBundle(name));
    }

    private IEnumerator LoadBundle(string name)
    {



        //Load the downloaded bundle
        AssetBundleCreateRequest requestbundle = AssetBundle.LoadFromFileAsync(Path.Combine(dataPath, "StaticMesh.unity3d"));
        yield return requestbundle;
        // bundle.LoadAllAssets();
        //Load an asset from the loaded bundle
        AssetBundle bundle = requestbundle.assetBundle;


        GameObject obj = bundle.LoadAsset<GameObject>(name);
        Vector3 pos = Vector3.zero;
        if (name == "Cube") pos = pos + new Vector3(0, 2, 0);
        else if (name == "Cylinder") pos = pos + new Vector3(0, 4, 0);
        GameObject gameobject = Instantiate(obj, pos, Quaternion.Euler(0, 45, 0)) as GameObject;
        bundle.Unload(false);

    }

    private IEnumerator ShowProgress(UnityWebRequest www)
    {
        while (!www.isDone)
        {
            Debug.Log(string.Format("Downloaded {0}", www.downloadedBytes));
            yield return new WaitForSeconds(.01f);
        }
        Debug.Log(string.Format("Downloaded {0}", www.downloadProgress));
        Debug.Log("Done");
    }

}
