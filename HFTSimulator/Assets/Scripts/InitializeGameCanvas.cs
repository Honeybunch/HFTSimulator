using UnityEngine;
using System.Collections;

public class InitializeGameCanvas : MonoBehaviour {

    public Canvas GameCanvas;

    public void Activate()
    {
        GameCanvas.gameObject.SetActive(true);
    }
}
