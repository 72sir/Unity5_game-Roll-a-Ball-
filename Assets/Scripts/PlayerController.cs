using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    private int count;
    private bool pause = true;
    // Text fields
    public Text countText, winText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        setCount();
	}
	
	// Update is called once per frame
	void Update () {
        if (pause)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            // hidden
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            count++;
            setCount();
        }
    }

    private void LateUpdate()
    {
    }


    void setCount() {
        countText.text = "Ваш счет: " + count.ToString();

        if (count >= 4)
        {
            winText.text = "Вы выиграли!";
            pause = false;
        }

    }


}
