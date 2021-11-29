using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Menu : MonoBehaviour
{
    public Canvas UI;

    private Canvas cnv;
    private bool paused = false;
    public bool Paused { get { return paused; } }
    public static Menu instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cnv = GetComponent<Canvas>();
        cnv.enabled = false;
    }

    public void Pause()
    {
        paused = !paused;
        cnv.enabled = paused;

        UI.enabled = !paused;

        Cursor.lockState = paused ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }
}
