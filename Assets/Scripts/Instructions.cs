using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene(0);
    }
}
