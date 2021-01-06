using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    public string[] staticDirection = {"Static N", "Static W", "Static S", "Static E"};
    public string[] runDirection = {"Run N", "Run W", "Run S", "Run E"};

    int _lastDirection;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;

        if (direction.magnitude < 0.01)
        {
            directionArray = staticDirection;
        }
        else
        {
            directionArray = runDirection;
            _lastDirection = DirectionToIndex(direction);
        }
        _anim.Play(directionArray[_lastDirection]);
    }

    private int DirectionToIndex(Vector2 direction)
    {
        Vector2 norDir = direction.normalized;

        float step = 360 / 4;
        float offset = step / 2;
        
        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
