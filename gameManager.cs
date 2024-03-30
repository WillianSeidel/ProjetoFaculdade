using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    public int pontos = 0;
    public bool hasblueKey = false;
    public float ykillzone = -3;

    public Transform playerReference;
    public TMP_Text textopontos;
    public Image imagekey;
    // Start is called before the first frame update
    void Start()
    {
        imagekey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerReference.position.y < ykillzone)
            SceneManager.LoadScene("Fase01");
        textopontos.text = "Pontos:" + pontos.ToString();

        if (hasblueKey)
        {
            imagekey.enabled = true;
        }
        if (pontos.ToString() == "10")
        SceneManager.LoadScene("Fim");
    }
}
