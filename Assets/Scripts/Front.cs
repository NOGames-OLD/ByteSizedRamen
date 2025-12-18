using UnityEngine;

public class Front : MonoBehaviour
{

    public Noodles currentNoodles;
    public Transform NoodleLocation;
    public GameObject closedNoodleBox;

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
        closedNoodleBox.SetActive(true);
        newNoodle.gameObject.SetActive(false);
        currentNoodles = newNoodle;
    }

    public void SendNoodles()
    {
        closedNoodleBox.SetActive(false);
        Destroy(currentNoodles.gameObject);
    }
}
