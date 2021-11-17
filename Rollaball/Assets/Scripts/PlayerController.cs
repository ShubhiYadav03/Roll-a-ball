using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public AudioSource source;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    private Rigidbody rb;
    private int count;
    private float MovementX;
    private float MovementY;
   
    // Start is called before the first frame update
    void Start()
    {
        source= GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        WinTextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        MovementX = movementVector.x;
        MovementY = movementVector.y;
    }

    void setCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            WinTextObject.SetActive(true);
          
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(MovementX, 0.0f, MovementY);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            source.Play();
        }
        
    }
}
