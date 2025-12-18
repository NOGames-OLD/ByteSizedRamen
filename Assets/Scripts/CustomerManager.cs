using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{

    public List<Order> orders = new List<Order>();
    private int orderNumber;
    public GameObject orderPrefab;
    public Transform orderRack;
    public GameObject OrderZoomIn;
    public GameObject customer;
    public GameObject takeOrderButton;
    public float money;
    public TMP_Text moneyText;
    public float startDayLength;
    float dayTime;
    public TMP_Text timeText;
    public GameObject gameOverScreen;
    public TMP_Text moneyEarnedText;

    public Vector2 timeBetweenCustomersRange;
    private float currentTimeBetweenCustomers;
    public int orderLimit;

    public Order selectedOrder;
    public Front front;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayTime = startDayLength;
        //currentTimeBetweenCustomers = UnityEngine.Random.Range(timeBetweenCustomersRange.x, timeBetweenCustomersRange.y);
        moneyText.text = "$" + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimeBetweenCustomers > 0)
        {
            currentTimeBetweenCustomers -= Time.deltaTime;
        }
        else if(orders.Count < orderLimit)
        {
            customer.SetActive(true);
            takeOrderButton.SetActive(true);
        }

        timeText.text = "Time Left: " + Mathf.CeilToInt(dayTime).ToString() + "s";

        if(dayTime > 0)
        {
            dayTime -= Time.deltaTime;
        }
        else
        {
            dayTime = 0;
            gameOverScreen.SetActive(true);
            moneyEarnedText.text = "Money Earned: $" + money.ToString();
        }
    }

    public void AddOrder()
    {
        Order newOrder = Instantiate(orderPrefab, transform.position, quaternion.identity, orderRack).GetComponent<Order>();
        orders.Add(newOrder);
        orderNumber++;
        newOrder.SetID(orderNumber);
        newOrder.SetOrderText("Noodles");
        newOrder.OrderZoomIn = OrderZoomIn;
        newOrder.customerManager = this;
        customer.SetActive(false);
        takeOrderButton.SetActive(false);
        if (orders.Count < orderLimit)
        {
            currentTimeBetweenCustomers = UnityEngine.Random.Range(timeBetweenCustomersRange.x, timeBetweenCustomersRange.y);
        }
    }

    public void FinishOrder()
    {
        FindObjectOfType<AudioManager>().Play("BellRing");
        if (front.currentNoodles != null & selectedOrder != null)
        {
            selectedOrder.HideOrderZoomIn();
            front.SendNoodles();
            bool wasAtLimit = false;
            if (orders.Count >= orderLimit)
            {
                wasAtLimit = true;
            }
            orders.Remove(selectedOrder);
            Destroy(selectedOrder.gameObject);
            
            float cookingDifference = Mathf.Abs(selectedOrder.askedCookingTime - ((front.currentNoodles.maxBurningTime + front.currentNoodles.maxCookingTime) - (front.currentNoodles.cookingTime + front.currentNoodles.burningTime)));
            Debug.Log(cookingDifference);
            if(cookingDifference > 2f)
            {
                money += 0.5f;   
            }else if(cookingDifference > 1f)
            {
                money += 1f;
            }
            else
            {
                money += 1.5f;  
            }
            moneyText.text = "$" + money.ToString();
            FindObjectOfType<AudioManager>().PlayDelayed("ReceiveCoins", 1f);

            if (wasAtLimit)
            {
                currentTimeBetweenCustomers = UnityEngine.Random.Range(timeBetweenCustomersRange.x, timeBetweenCustomersRange.y);
            }
            
        }
    }
}
