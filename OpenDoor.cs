using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject wallToDestroy;
    gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindAnyObjectByType<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenSelectedDoor();
        }
    }

    public void OpenSelectedDoor()
    {
        if (gm.hasblueKey)
        Destroy(wallToDestroy.gameObject);
    }
}