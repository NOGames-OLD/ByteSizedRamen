using UnityEngine;
using TMPro;

public class OrderZoomIn : MonoBehaviour
{

    public TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string newText)
    {
        text.text = newText;
    }
}
