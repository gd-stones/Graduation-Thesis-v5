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
        // Action 1-10
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
        if (action == "boxing" || Input.GetKeyDown(KeyCode.Alpha3))
        {
            startRotation = transform.rotation;
            PlayAction("boxing");
        }
        if (action == "hook_punch" || Input.GetKeyDown(KeyCode.Alpha4))
        {
            startRotation = transform.rotation;
            PlayAction("hook_punch");
        }
        if (action == "fireball" || Input.GetKeyDown(KeyCode.Alpha5))
        {
            startRotation = transform.rotation;
            PlayAction("fireball");
        }
        if (action == "materlo_2" || Input.GetKeyDown(KeyCode.Alpha6))
        {
            startRotation = transform.rotation;
            PlayAction("materlo_2");
        }
        if (action == "chapa_giratoria" || Input.GetKeyDown(KeyCode.Alpha7))
        {
            startRotation = transform.rotation;
            PlayAction("chapa_giratoria");
        }
        if (action == "front_twist_flip" || Input.GetKeyDown(KeyCode.Alpha8))
        {
            startRotation = transform.rotation;
            PlayAction("front_twist_flip");
        }
        if (action == "butterfly_twirl" || Input.GetKeyDown(KeyCode.Alpha9))
        {
            startRotation = transform.rotation;
            PlayAction("butterfly_twirl");
        }
        if (action == "breakdance_1990" || Input.GetKeyDown(KeyCode.Alpha0))
        {
            startRotation = transform.rotation;
            PlayAction("breakdance_1990");
        }

        // Movement
        if (action == "idle-walking" || Input.GetKey(KeyCode.W))
        {
            anim.SetBool("idle-walking", true);
        }
        else if (action == "idle" || Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("idle-walking", false);
        }

        if (action == "idle-backward" || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("idle-backward", true);
        }
        else if (action == "idle" || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("idle-backward", false);
        }

        if (action == "left_turn" || Input.GetKeyDown(KeyCode.A) ||
            (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.A)))
        {
            PlayAction("left_turn");
        }
        if (action == "right_turn" || Input.GetKeyDown(KeyCode.D) ||
            (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.D)))
        {
            PlayAction("right_turn");
        }

        if (action == "idle-running" || Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("idle-running", true);
        }
        else if (action == "idle" || Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("idle-running", false);
        }

        if (action == "idle-fast_run" || Input.GetKey(KeyCode.E))
        {
            anim.SetBool("idle-fast_run", true);
        }
        else if (action == "idle" || Input.GetKeyUp(KeyCode.E))
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