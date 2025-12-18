using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UIElements;

public class Order : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public int orderID;
    private bool mouse_over = false;
    public GameObject OrderZoomIn;
    public TMP_Text OrderText;
    public CustomerManager customerManager;
    public Noodles myNoodleImage;
    public float askedCookingTime;

    void Start()
    {
        askedCookingTime = Random.Range(0f, myNoodleImage.cookingTime + (myNoodleImage.cookingTime/2f));
        myNoodleImage.SetCookingTime(askedCookingTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData){
        if(customerManager.selectedOrder == null || customerManager.selectedOrder == this){
            mouse_over = true;
            OrderZoomIn.SetActive(true);
            OrderZoomIn.GetComponent<OrderZoomIn>().SetText(OrderText.text);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(customerManager.selectedOrder != null && customerManager.selectedOrder != this)
        {
            customerManager.selectedOrder.HideOrderZoomIn();
        }
        customerManager.selectedOrder = this;
        OrderZoomIn.SetActive(true);
        OrderZoomIn.GetComponent<OrderZoomIn>().SetText(OrderText.text);
        FindObjectOfType<AudioManager>().Play("ReceiptRustle");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(customerManager.selectedOrder == null){
            mouse_over = false;
            OrderZoomIn.SetActive(false);
        }
    }

    public void HideOrderZoomIn()
    {
        mouse_over = false;
        OrderZoomIn.SetActive(false);
    }

    public void SetID(int id)
    {
        orderID = id;
    }
    
    public void SetOrderText(string text)
    {
        string newText = "Order #" + orderID.ToString() + "\n" + text;
        OrderText.text = newText;
    }
}
