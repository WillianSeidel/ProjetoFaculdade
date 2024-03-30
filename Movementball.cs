using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movementball : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody rb;
    public gameManager gm;
    //AudioSource audioSource;
    public Color targetColor = Color.yellow;
    public fim Fim;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //audioSource = GetComponwent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<jump>() != null)
        {
            float jumpForce = otherObject.GetComponent<jump>().jumpForce;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (otherObject.tag == "Box")
        {
            otherObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        if (otherObject.GetComponent<OpenDoor>() != null)
        {
            otherObject.GetComponent<OpenDoor>().OpenSelectedDoor();
        }
    }
    

    private void OnCollisionExit(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        
        if (otherObject.GetComponent<BrokenFloor>() != null)
        {
            BrokenFloor brokenFloor;
            brokenFloor = otherObject.GetComponent<BrokenFloor>();
            
            brokenFloor.perdeVida();
        }
        
        //if (otherObject.tag == "Fim")
            //GameObject.FindAnyObjectByType<gameManager>().EndGame();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coletavel")
        {
            Destroy(other.gameObject);
            gm.pontos++;
            //audioSource.Play();
        }
        if (other.tag == "key")
        {
            Destroy(other.gameObject);
            GameObject.FindAnyObjectByType<gameManager>().hasblueKey = true;
        }
        //if (other.CompareTag("Box"))
        //{
          //  CheckAllBoxesPainted(targetColor);
        //}
    }
    //parte da box amarela verificar por que não chama a cena fim
    //public void CheckAllBoxesPainted(Color targetColor)
    //{
      //  GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        //foreach (GameObject box in boxes)
        //{
          //  Renderer boxRenderer = box.GetComponent<Renderer>();
            //if (boxRenderer != null && boxRenderer.material.color != targetColor)
            //{
   
              //  return;
            //}
        //}
        //SceneManager.LoadScene("Fim");
    //}
}