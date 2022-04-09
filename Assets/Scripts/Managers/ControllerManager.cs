using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public List<PlayerController> controllableObjects;
    private int currentControllableObject = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            disableCurrentControllableObject();
            currentControllableObject = (currentControllableObject + 1) % controllableObjects.Count;
        }
        enableCurrentControllableObject();
    }

    private void disableCurrentControllableObject()
    {
        if (controllableObjects.Count == 0)
        {
            return;
        }

        controllableObjects[currentControllableObject].isEnabled = false;
    }

    private void enableCurrentControllableObject()
    {
        if (controllableObjects.Count == 0)
        {
            return;
        }

        controllableObjects[currentControllableObject].isEnabled = true;
    }

}
