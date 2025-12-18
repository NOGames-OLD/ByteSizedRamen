using UnityEngine;

public class Front : MonoBehaviour
{

    public Noodles currentNoodles;
    public Transform NoodleLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendNoodleToFront(Noodles newNoodle)
    {
        newNoodle.transform.SetParent(NoodleLocation);
        newNoodle.transform.position = NoodleLocation.transform.position;
        currentNoodles = newNoodle;
    }

    public void SendNoodles()
    {
        Destroy(currentNoodles.gameObject);
    }
}
