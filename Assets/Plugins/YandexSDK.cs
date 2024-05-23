using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class YandexSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Authorization();

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private RawImage photoImage;

    public void LoadData()
    {
        Authorization();
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            UnityEngine.Debug.Log(request.error);
        }
        else
        {
            photoImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
