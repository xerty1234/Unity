using UnityEngine;
using System.Collections;

[System.Serializable]
public class Animatio
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
}

public class PlayerCtrl : MonoBehaviour {
    private float h = 0.00f;
    private float v = 0.00f;

    private Transform tr;
    public float movespeed = 10.0f;
    public float rotspeed = 100.0f;

    public Animatio anim;
    public Animation _animation;
	public AudioSource Run;

    private GameMgr gameMgr;


    // Use this for initialization
    void Start () {

        tr = GetComponent<Transform>();
        _animation = GetComponentInChildren<Animation>();

        _animation.clip = anim.idle;
        _animation.Play();
     

    }
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

 
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * Time.deltaTime * movespeed, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotspeed * Input.GetAxis("Mouse X"));

	

        if (v >= 0.1f)
        {
            _animation.CrossFade(anim.runForward.name, 0.3f);
			if (!Run.isPlaying) {
				Run.Play ();
			}
        }
        else if (v<=-0.1f)
        {
            _animation.CrossFade(anim.runBackward.name, 0.3f);
			if (!Run.isPlaying) {
				Run.Play ();
			}
        }
        else if(h>=0.1f)
        {
            _animation.CrossFade(anim.runRight.name, 0.3f);
			if (!Run.isPlaying) {
				Run.Play ();
			}
        }
        else if(h<=-0.1f)
        {
            _animation.CrossFade(anim.runLeft.name, 0.3f);
			if (!Run.isPlaying) {
				Run.Play ();
			}
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.3f);
        }

    }

	void OnCollisionEnter ()
	{
		
	}

	void OnDisable(){
		Vector3 reset = Vector3.zero;
		tr.transform.position = reset;
	}
}
