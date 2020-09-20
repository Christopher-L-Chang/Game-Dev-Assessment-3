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
        startPos.Set(9, 17);
        endPos.Set(18, 17);
        startTime = Time.time;
        teethController.SetTrigger("Side");
        pacman.transform.Rotate(0,180,0);
        backgroundMusic.PlayDelayed(4);
        pacmanMove.PlayDelayed(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(pacman.transform.position, endPos) > 0f)
        {
            float speed = (Time.time - startTime) / duration;
            pacman.transform.position = Vector2.Lerp(startPos, endPos, speed);
        }
        else
        {
            pacman.transform.position = endPos;
            startTime = Time.time;
            switch (pos)
            {
                case 1:
                    pos = 2;
                    teethController.SetTrigger("Down");
                    pacman.transform.Rotate(0, 0, 0);
                    startPos = endPos;
                    endPos.Set(18, 11);
                    break;
                case 2:
                    pos = 3;
                    teethController.SetTrigger("Side");
                    pacman.transform.Rotate(0, 180, 0);
                    startPos = endPos;
                    endPos.Set(9, 11);
                    break;
                case 3:
                    pos = 4;
                    teethController.SetTrigger("Up");
                    pacman.transform.Rotate(0, 0, 0);
                    startPos = endPos;
                    endPos.Set(9, 17);
                    break;
                case 4:
                    pos = 1;
                    teethController.SetTrigger("Side");
                    pacman.transform.Rotate(0, 180, 0);
                    startPos = endPos;
                    endPos.Set(18, 17);
                    break;
                default:
                    pos = 1;
                    startPos = endPos;
                    endPos.Set(18, 11);
                    break;
            }
        }
    }
}
