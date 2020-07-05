using UnityEngine;

public class Colliders : MonoBehaviour
{
    private Renderer objRenderer;
    private Color objColor;

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = transform.GetComponent<Renderer>();
        objColor = objRenderer.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter!!");
            objRenderer.material.SetColor("_Color", Color.red);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            objRenderer.material.SetColor("_Color", objColor);
        }
    }
}
