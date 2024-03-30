using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFood : MonoBehaviour
{
    public float rotateSpeed = 20;
    public GameObject objectToSpawn;
    public int numItens = 7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);

        while (numItens > 0)
        {
            float spawnX = transform.position.x + Random.Range(-4.0f, 4.0f);
            float spawnZ = transform.position.z + Random.Range(-4.0f, 4.0f);

            Vector3 positionToInstantiate = new Vector3(spawnX, transform.position.y, spawnZ);

            Instantiate(objectToSpawn, positionToInstantiate, Quaternion.identity);

            numItens--;
        }
    }
}
