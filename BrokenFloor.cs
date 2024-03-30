using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
            Destroy(this.gameObject);



    }
    public void perdeVida()
    {
        life--;
        if (life == 1)
            GetComponent<MeshRenderer>().material.color = new Color(255, 0, 200);
       //if (life == 1)
        //  GetComponent<MeshRenderer>().material.color = new Color(1f, 0, 0);
    }
}
