using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;

    private Animator anim;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Movement();
    }

    public void Movement()
    {
        Debug.Log("horizontalInput: " + horizontalInput);
        Debug.Log("verticalInput: " + verticalInput);
    }
}
