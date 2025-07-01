using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer;
    private float idleTime, patrolTime;

    private float traceDist = 5f;
    
    void Start()
    {
        Init(10f, 3f);
    }

    protected override void Init(float hp, float speed)
    {
        base.Init(hp, speed);
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            patrolTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", true);
            
            ChangeState(MonsterState.PATROL);
        }

        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            animator.SetBool("isRun", true);

            ChangeState(MonsterState.TRACE);
        }
    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        
        timer += Time.deltaTime;
        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", false);
            
            ChangeState(MonsterState.IDLE);
        }
        
        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);

        if (targetDist > traceDist)
        {
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Attack()
    {
        
    }
}