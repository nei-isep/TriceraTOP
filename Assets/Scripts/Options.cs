
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {
    public AudioSource audioData;

    public void Play() {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        SceneManager.LoadScene(2);
    }

    public void Instructions() {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        SceneManager.LoadScene(1);
    }

    public void Quit() {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        Application.Quit();
    }
}
