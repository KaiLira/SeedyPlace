using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public float speed;
    public Rigidbody body;
    public TargetHolder targetHolder;
    public EnemyDamageHandler damageHandler;
    public AnimationCurve speedCurve;
    private void FixedUpdate()
    {
        body.velocity = 
            (targetHolder.target.transform.position - transform.position).normalized *
            speed *
            (1f + speedCurve.Evaluate(damageHandler.DeathProgress()));
    }
}
