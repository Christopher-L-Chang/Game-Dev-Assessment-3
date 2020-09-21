using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject pacman;
    private Vector2 startPos;
    private Vector2 endPos;
    private float startTime;
    private float timer = 0;
    private int pos = 1;
    [SerializeField]
    private float duration = 2f;
    public Animator teethController;
    [SerializeField]
    private AudioSource pacmanMove;
    [SerializeField]
    private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        startPos.Set(1, 27);
        endPos.Set(6, 27);
        startTime = Time.time;
        teethController.SetTrigger("Side");
        pacman.transform.Rotate(0,180,0);
        backgroundMusic.PlayDelayed(4);
        pacmanMove.PlayDelayed(4);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < duration)
        {
            float speed = timer/duration;
            pacman.transform.position = Vector2.Lerp(startPos, endPos, speed);
        }
        else
        {
            timer = 0;
            pacman.transform.position = endPos;
            startTime = Time.time;
            switch (pos)
            {
                case 1:
                    pos = 2;
                    teethController.SetTrigger("Down");
                    pacman.transform.Rotate(0, 0, 0);
                    startPos = endPos;
                    endPos.Set(6, 23);
                    break;
                case 2:
                    pos = 3;
                    teethController.SetTrigger("Side");
                    pacman.transform.Rotate(0, 180, 0);
                    startPos = endPos;
                    endPos.Set(1, 23);
                    break;
                case 3:
                    pos = 4;
                    teethController.SetTrigger("Up");
                    pacman.transform.Rotate(0, 0, 0);
                    startPos = endPos;
                    endPos.Set(1, 27);
                    break;
                case 4:
                    pos = 1;
                    teethController.SetTrigger("Side");
                    pacman.transform.Rotate(0, 180, 0);
                    startPos = endPos;
                    endPos.Set(6, 27);
                    break;
                default:
                    pos = 1;
                    startPos = endPos;
                    endPos.Set(6, 27);
                    break;
            }
        }
    }
}
