using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    public void LoadGameScene() {
        FindObjectOfType<SceneTransition>().ChangeScene(1);
    }
}
