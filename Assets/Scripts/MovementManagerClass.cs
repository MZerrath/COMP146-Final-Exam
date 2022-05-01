using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManagerClass : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private Vector3 spawnPosition;
    private GameObject activeObject;

    // UI Elements
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button forwardButton;
    public Button backwardButton;
    public Button createButton;
    public Button destroyButton;
    public Button resetButton;

    // Grabs main camera for use of positioning when the player clicks "Reset Camera"
    void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera");
    }

    // Methods for when the player activates movement buttons;
    public void MoveUp()
    {
        activeObject.transform.position += new Vector3(0, 1f, 0);
    }

    public void MoveDown()
    {
        // If the movement of the object does NOT risk going below 0 on the Y axis
        if (!(activeObject.transform.position.y - 1f <= 0))

        activeObject.transform.position += new Vector3(0, -1f, 0);
    }

    public void MoveLeft()
    {
        activeObject.transform.position += new Vector3(-1f, 0, 0);
    }

    public void MoveRight()
    {
        activeObject.transform.position += new Vector3(1f, 0, 0);
    }

    public void MoveForward()
    {
        activeObject.transform.position += new Vector3(0, 0, 1f);
    }

    public void MoveBackward()
    {
        activeObject.transform.position += new Vector3(0, 0, -1f);
    }

    // Spawn the prefab
    public void SpawnPrefab()
    {
        // Prepares the spawn position for the prefab,
        // where object will always spawn 5 units ahead of camera
        spawnPosition = camera.transform.position + new Vector3(0, 0, 5f);

        // The new prefab will always spawn 5 units ahead of the camera
        if(activeObject == null)
        {
            activeObject = Instantiate(prefab) as GameObject;
            activeObject.transform.position = spawnPosition;
        }
        
        // Toggle button interactivity after object spawns
        ToggleButtons();
    }

    // Destroys the prefab
    public void DestroyPrefab()
    {
        // Destroys object
        Destroy(activeObject);

        // Toggle the buttons
        ToggleButtons();
    }

    // Resets the camera to where the prefab is
    public void ResetCamera()
    {
        // Camera will always spawn 5 units behind the prefab
        camera.transform.position = activeObject.transform.position + new Vector3(0, 0, -5f);
    }

    // Toggles button interactivity
    // All buttons, except the create button, are disabled by default
    private void ToggleButtons()
    {
        upButton.interactable = !upButton.interactable;
        downButton.interactable = !downButton.interactable;
        leftButton.interactable = !leftButton.interactable;
        rightButton.interactable = !rightButton.interactable;
        forwardButton.interactable = !forwardButton.interactable;
        backwardButton.interactable = !backwardButton.interactable;
        createButton.interactable = !createButton.interactable;
        destroyButton.interactable = !destroyButton.interactable;
        resetButton.interactable = !resetButton.interactable;
    }
}
