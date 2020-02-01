using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFallingElements : MonoBehaviour
{
    public GameObject elementToGenerate;
    public int timeGeneration;

    private float initialPosition;
    private float finalPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition =   transform.position.x - GetComponent<BoxCollider2D>().bounds.size.x;
        finalPosition =     transform.position.x + GetComponent<BoxCollider2D>().bounds.size.x;

     
            StartCoroutine("GenerateElements");
        
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator GenerateElements()
    {
        while (true) {
            GameObject g = Instantiate(elementToGenerate, new Vector3(Random.Range(initialPosition, finalPosition), transform.position.y, transform.position.z), Quaternion.identity);
            g.transform.parent = this.transform;
            yield return new WaitForSeconds(timeGeneration);
        }
       
        
        
    }
}
