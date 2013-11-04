using UnityEngine;
using System.Collections;

public class KeepMusic : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
