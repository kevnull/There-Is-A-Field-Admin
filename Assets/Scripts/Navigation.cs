using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Core;


public class Navigation : MonoBehaviour {

    private bool initializingGS = false;
    private bool requestingAudio = false;
    private bool requestedAllAudio = false;
    public AudioSource quoteaudio;
    private string playerId = "";
    public GameObject canvas;
    public GameObject button;
    public GameObject delbutton;
    private List<string> allQuotes = new List<string>();
    private Dictionary<string, List<string>> allAudio = new Dictionary<string, List<string>>();

    private void Awake()
    {
    }

    void Update()
    {
        if (playerId != "")
        {
            if (gameObject.activeSelf && !requestingAudio && !requestedAllAudio)
            {
                RequestAllAudio();
            }
        }
        else if (!initializingGS)
        {
            InitGS();
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void InitGS()
    {
        initializingGS = true;
        // authenticate
        new DeviceAuthenticationRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                playerId = response.UserId;
                Debug.Log("Device Authenticated..." + response.UserId);
            }
            else
            {
                Debug.Log("Error Authenticating Device...");
            }
            initializingGS = false;
        });
    }

    private void RequestAllAudio()
    {
        string quotename = "";
        requestingAudio = true;

        //download all files
        new LogEventRequest().SetEventKey("LOAD_AUDIO").Send((response) =>
        {
            if (!response.HasErrors)
            {
                GSData data = response.ScriptData;
                int i = 0;
                if (data != null)
                {
                    string uploadId = data.GetString("uploadId" + i);
                    quotename = data.GetString("Quote" + i);

                    while (uploadId != null)
                    {
                        Debug.Log(uploadId + " / " + quotename);
                        if (!allQuotes.Contains(quotename))
                        {
                            allQuotes.Add(quotename);
                        }
                        if (!allAudio.ContainsKey(quotename))
                        {
                            allAudio.Add(quotename, new List<string>());
                        }
                        allAudio[quotename].Add(uploadId);

                        i++;
                        uploadId = data.GetString("uploadId" + i);
                        quotename = data.GetString("Quote" + i);
                    }

                    requestedAllAudio = true;
                }
                requestingAudio = false;
            }
        });
    }

    public void ListAudio()
    {
        int i = 0;
        foreach (string quote in allQuotes)
        {
            Debug.Log(quote);
            foreach(string id in allAudio[quote])
            {
                Debug.Log(id);
                GameObject buttonGO = Instantiate(button);
                buttonGO.SetActive(true);
                Button newbutton = buttonGO.GetComponent<Button>();
                newbutton.transform.SetParent(canvas.transform, false);
                string btntext = quote + ": " + id;
                newbutton.GetComponentInChildren<Text>().text = btntext;
                newbutton.onClick.AddListener(() => { DownloadAFile(id, quote); } );
                newbutton.transform.localPosition = new Vector2(10, i*-35 -20);

                GameObject dbuttonGO = Instantiate(delbutton);
                dbuttonGO.SetActive(true);
                newbutton = dbuttonGO.GetComponent<Button>();
                newbutton.transform.SetParent(canvas.transform, false);
                newbutton.onClick.AddListener(() => { DeleteAFile(id); });
                newbutton.transform.localPosition = new Vector2(780, i *-35 -20);

                i++;
            }
        }

    }

    // Download a file from GameSparks given an uploadId
    private void DownloadAFile(string uploadId = "", string quote = "")
    {
        //Get the url associated with the uploadId
        new GetUploadedRequest().SetUploadId(uploadId).Send((response) =>
        {
            //pass the url to our coroutine that will accept the data
            StartCoroutine(DownloadAudio(response.Url, quote));
        });
    }

    private void DeleteAFile(string uploadId = "")
    {
        new LogEventRequest().SetEventKey("DELETE_AUDIO")
            .SetEventAttribute("uploadId", uploadId)
            .Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log(response.JSONString);
                GSData data = response.ScriptData;
            }
        });
    }

    private IEnumerator DownloadAudio(string downloadUrl, string quotename)
    {
        WWW www = new WWW(downloadUrl);

        while (!www.isDone)
        {
            Debug.Log("Downloading: " + downloadUrl);
            yield return www;
        }

        quoteaudio.clip = www.GetAudioClip(false, false, AudioType.WAV);
        quoteaudio.Play();
    }
}
