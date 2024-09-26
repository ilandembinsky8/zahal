using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;

    private static string _videoPath = Application.streamingAssetsPath + "\\LastKinVideo.mp4";

    private bool _isVideoFound;
    
    private void Start()
    {
        ValidateVideoExistence();
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

    private void OnEnable()
    {
        videoPlayer.time = 0;
        videoPlayer.Play();
    }

    private void OnDisable()
    {
        videoPlayer.Stop();
    }
}
