using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    void Start() {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();


        // Set playback settings
        videoPlayer.playOnAwake = true;
        videoPlayer.isLooping = true;

        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }
}