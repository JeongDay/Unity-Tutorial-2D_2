using System.IO;
using UnityEditor.UI;
using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    
    public float hp;
    public float speed;

    protected virtual void Init(float hp, float speed)
    {
        this.hp = hp;
        this.speed = speed;
        
        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }
    
    void Update()
    {
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