using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerInimigo : MonoBehaviour
{
    public GameObject Inimigo;
    public float intervalo = 3.0f;

    private float tempoDeSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoDeSpawn += Time.deltaTime;
        if (tempoDeSpawn >= intervalo)
        {
            Instantiate(Inimigo, gameObject.transform);
            tempoDeSpawn = 0.0f;
        }
    }
}
