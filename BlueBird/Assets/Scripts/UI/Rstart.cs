using UnityEngine;
using UnityEngine.SceneManagement;

public class Rstart : MonoBehaviour {
    public void LoadMenuScene() {
        FindObjectOfType<SceneTransition>().ChangeScene(0);
    }
}
