using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public const float Speed = 10;
    private Rigidbody rb;
    private const int Total = 8;
    private int Count = 0;
    public Text CountText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        setCountText();
    }

    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(Movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Count++;
        }
        setCountText();
    }

    void setCountText()
    {
        if (Count >= Total)
        {
            CountText.color = Color.yellow;
            CountText.text = "Count: " + Count.ToString() + "/" + Total.ToString() + " Mission complete!";
        }
        else
        {
            CountText.text = "Count: " + Count.ToString() + "/" + Total.ToString();
        }
    }
}
