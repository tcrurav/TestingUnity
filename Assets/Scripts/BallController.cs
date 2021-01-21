using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private int count;
    public float speed;
    private Rigidbody rb;
    public Text countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        count++;
        countText.text = "Count: " + count.ToString();

        if(count == 7)
        {
            resetScene();
        }
    }

    private void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("SampleScene").buildIndex);
    }
}
