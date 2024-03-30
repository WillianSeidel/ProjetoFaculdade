using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fim : MonoBehaviour
{
    public Color targetColor = Color.yellow; 
    public string finalSceneName = "Fim";
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Renderer boxRenderer = other.GetComponent<Renderer>();
            if (boxRenderer != null && boxRenderer.material.color == targetColor)
            {
                CheckAllBoxesPainted();
            }
        }
    }
    public void CheckAllBoxesPainted()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (GameObject box in boxes)
        {
            Renderer boxRenderer = box.GetComponent<Renderer>();
            if (boxRenderer != null && boxRenderer.material.color != targetColor)
            {
                // Se uma das caixas não estiver pintada de amarelo, saia da função
                return;
            }
        }

        // Se todas as caixas estiverem pintadas de amarelo, carregue a cena final
        SceneManager.LoadScene("Fim");
    }
}
