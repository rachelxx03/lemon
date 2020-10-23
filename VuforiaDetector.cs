using UnityEngine;


public class VuforiaDetector : DefaultTrackableEventHandler
{
    public GameObject gui;
    protected override void OnTrackingFound()
    {
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName +
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);
        base.OnTrackingFound();
        int index = 0;
        if (FindAudio(mTrackableBehaviour.TrackableName, ref index))
        {
            if (AudioAssets.audioPlayerList[index].gui != null)
                gui = AudioAssets.audioPlayerList[index].gui;
            AudioAssets.audioSource.clip = AudioAssets.audioPlayerList[index].audioClip;
            AudioAssets.audioSource.Play();
            if (gui != null)

            {
                if(gui.name=="ToaNha")
                {
                    if (gui.transform.GetChild(3).gameObject.GetComponent<LienHeControl>().currentObj!=null)
                 gui.transform.GetChild(3).gameObject.GetComponent<LienHeControl>().currentObj.SetActive(false); 
                }
                gui.SetActive(true);
               
            }

        }

    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        if(AudioAssets.audioSource!=null)
        if (AudioAssets.audioSource.isPlaying)
            AudioAssets.audioSource.Stop();
        if (gui != null)
        {
          
                gui.SetActive(false);
        }
    }




    public bool FindAudio(string name, ref int index)
    {
        for (int i = 0; i < AudioAssets.audioPlayerList.Count; i++)
        {
            if (name == AudioAssets.audioPlayerList[i].name)
            {
                index = i;
                return true;
            }
        }
        return false;
    }



}
