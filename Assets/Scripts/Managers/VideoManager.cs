using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
 
    public UnityEvent OnVideoEnded;
    
    private static string _videoPath = Application.streamingAssetsPath + "\\LastKinVideo.mp4";

    private bool _isVideoFound;

    private void Awake()
    {
        ValidateVideoExistence();
        videoPlayer.playOnAwake = true;
        videoPlayer.Prepare();
        videoPlayer.loopPointReached += source => OnVideoEnded.Invoke();
    }
    
    private void ValidateVideoExistence()
    {
        if (File.Exists(_videoPath))
        {
            Debug.Log($"Found Video on path {_videoPath}");
            _isVideoFound = true;
            videoPlayer.url = _videoPath;
        }
    }
}
