using System;
using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    
    public Transform target;
    
    public float hp;
    public float speed;
    public float attackTime;
    
    protected float moveDir;
    protected float targetDist;
    
    protected bool isTrace;

    protected virtual void Init(float hp, float speed, float attackTime)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);
        
        Vector3 monsterDir = Vector3.right * moveDir;
        Vector3 playerDir = (transform.position - target.position).normalized;

        float dotValue = Vector3.Dot(monsterDir, playerDir);
        
        // isTrace = dotValue < 0f;
        isTrace = dotValue < -0.5f && dotValue >= -1f;
        
        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState)
            monsterState = newState;
    }
}