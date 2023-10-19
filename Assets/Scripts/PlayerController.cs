using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Animation
    [SerializeField] private Animator anim;
    //[SerializeField] private Rigidbody robotRigidbody;

    private Quaternion startRotation;
    private float time;

    // Hand Tracking
    public UDPReceive udpReceive;
    string action;

    private void Update()
    {
        action = udpReceive.data;
        ActionController();
    }

    private void ActionController()
    {
        if (action == "jump_attack" || Input.GetKeyDown(KeyCode.Alpha1))
        {
            startRotation = transform.rotation;
            PlayAction("jump_attack");
        }
        if (action == "punching_bag" || Input.GetKeyDown(KeyCode.Alpha2))
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

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("idle-walking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("idle-walking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("idle-backward", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("idle-backward", false);
        }

        if (Input.GetKeyDown(KeyCode.A) ||
            (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.A)))
        {
            PlayAction("left_turn");
        }
        if (Input.GetKeyDown(KeyCode.D) ||
            (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.D)))
        {
            PlayAction("right_turn");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("idle-running", true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("idle-running", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("idle-fast_run", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("idle-fast_run", false);
        }
    }

    private void PlayAction(string action)
    {
        string[] actions =  { "jump_attack", "punching_bag", "boxing", "hook_punch", "fireball",
            "materlo_2", "chapa_giratoria", "front_twist_flip", "butterfly_twirl", "breakdance_1990", 
            "left_turn", "right_turn" };

        foreach (var act in actions)
            anim.ResetTrigger(act);
        anim.SetTrigger(action);
    }
    private void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(startRotation, Quaternion.identity, time);
        time += Time.deltaTime;
    }
}