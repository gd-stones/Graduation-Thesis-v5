using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    //[Header("Movement Parameters")]
    //private float horizontalInput;
    //private float verticalInput;
    //[Range(0f, 100f)]
    //[SerializeField] private float speed = 8f;
    //[SerializeField] private float turnSpeed = 2f;
    //private float moveDistance;

    // Animation
    [SerializeField] private Animator anim;

    [SerializeField] private Rigidbody robotRigidbody;

    private bool isWalking = false;
    private bool isRunning = false;
    private bool isIdle = true;

    private Quaternion startRotation;
    private float time;

    private void Start()
    {
        startRotation = transform.rotation;
    }

    private void Update()
    {
        ActionController();
    }

    //private void Movement()
    //{
    //    horizontalInput = Input.GetAxis("Horizontal");
    //    verticalInput = Input.GetAxis("Vertical");

    //    if (horizontalInput > 0.01f)
    //    {
    //        anim.ResetTrigger("turn-left");
    //        anim.SetTrigger("turn-right");
    //    }
    //    else if (horizontalInput < -0.01f)
    //    {
    //        anim.ResetTrigger("turn-right");
    //        anim.SetTrigger("turn-left");
    //    }

    //    if (verticalInput > 0.01f)
    //    {
    //        Debug.Log("aaaaaaaaaaaaaaa");
    //        anim.SetBool("retro-grade", false);
    //        anim.SetBool("go-ahead", true);
    //    }
    //    else if (verticalInput < -0.01f)
    //    {
    //        Debug.Log("bbbbbbbbbbbb");
    //        anim.SetBool("go-ahead", false);
    //        anim.SetBool("retro-grade", true);
    //    }
    //    else if (verticalInput > 0.01f && Input.GetKey(KeyCode.LeftShift)
    //        || verticalInput > 0.01f && Input.GetKey(KeyCode.RightShift))
    //        anim.SetBool("run", true);

    //    moveDistance = verticalInput * speed;

    //    var angle = horizontalInput * Vector3.up;
    //    var lastAngle = angle * turnSpeed;
    //    transform.Rotate(lastAngle);

    //    walkerRobotRigidbody.AddForce(transform.forward * moveDistance);
    //}



    private void ActionController()
    {
        if (isIdle)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                startRotation = transform.rotation;
                PlayAction("jump_attack");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                startRotation = transform.rotation;
                PlayAction("punching_bag");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                startRotation = transform.rotation;
                PlayAction("boxing");
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                startRotation = transform.rotation;
                PlayAction("hook_punch");
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                startRotation = transform.rotation;
                PlayAction("fireball");
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                startRotation = transform.rotation;
                PlayAction("materlo_2");
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                startRotation = transform.rotation;
                PlayAction("chapa_giratoria");
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                startRotation = transform.rotation;
                PlayAction("front_twist_flip");
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                startRotation = transform.rotation;
                PlayAction("butterfly_twirl");
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                startRotation = transform.rotation;
                PlayAction("breakdance_1990");
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            SetState("isWalking");
            anim.SetBool("idle-walking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            SetState();
            anim.SetBool("idle-walking", false);
        }
        if (isWalking)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.ResetTrigger("right_turn");
                anim.SetTrigger("left_turn");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.ResetTrigger("left_turn");
                anim.SetTrigger("right_turn");
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)
               || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.RightShift))
            {
                SetState("isRunning");
                anim.SetBool("idle-walking", false);
                anim.SetBool("walking-running", true);
            }
        }
        if (isRunning)
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("idle-backward", true);
            isIdle = false;
        }
    }

    private void PlayAction(string action)
    {
        string[] actions =  { "jump_attack", "punching_bag", "boxing", "hook_punch", "fireball",
            "materlo_2", "chapa_giratoria", "front_twist_flip", "butterfly_twirl", "breakdance_1990" };

        foreach (var act in actions)
            anim.ResetTrigger(act);
        anim.SetTrigger(action);
    }
    private void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(startRotation, Quaternion.identity, time);
        time += Time.deltaTime;
    }
    private void SetState(string state = "isIdle")
    {
        switch (state)
        {
            case "isWalking":
                isWalking = true;
                isRunning = false;
                isIdle = false;
                break;
            case "isRunning":
                isWalking = false;
                isRunning = true;
                isIdle = false;
                break;
            default:
                isWalking = false;
                isRunning = false;
                isIdle = true;
                break;
        }
    }
}