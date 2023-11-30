using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBtn : MonoBehaviour
{
    public void OnPressMove()
    {
        GameManagerScr.Instance.car.isPushedMove = true;
        transform.Rotate(20, 0, 0);
    }

    public void OnReleaseMove()
    {
        GameManagerScr.Instance.car.isPushedMove = false;
        transform.Rotate(-20, 0, 0);
    }


    public void OnPressStop()
    {
        GameManagerScr.Instance.car.isPushedStop = true;
        transform.Rotate(20, 0, 0);
    }

    public void OnReleaseStop()
    {
        GameManagerScr.Instance.car.isPushedStop = false;
        transform.Rotate(-20, 0, 0);
    }
}