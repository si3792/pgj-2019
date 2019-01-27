using UnityEngine;

public class TemporaryObject : MonoBehaviour
{

    public float lifetime = 1.0f;

    // Use this for initialization
    void Start()
    {
        Invoke("Disable", lifetime);
    }

    // Update is called once per frame
    void Disable()
    {
        Destroy(gameObject);
    }
}
