using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Cube : MonoBehaviour
{
    private ObstacleCollision _obstacleCollision;
    private PointScoring _pointScoring;
    
    [Inject]
    public void Init(ObstacleCollision collision, PointScoring pointScore)
    {
        this._obstacleCollision = collision;
        this._pointScoring = pointScore;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
            _obstacleCollision.Collide();
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Point"))
            _pointScoring.AddScore();
    }
}
