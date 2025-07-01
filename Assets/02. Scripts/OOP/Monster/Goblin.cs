using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer;
    private float ranDir;
    private float idleTime, patrolTime;

    private float percent;
    private Vector3 startPos, endPos;
    
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
            ranDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(ranDir, 1, 1);
            animator.SetBool("isRun", true);
            
            patrolTime = Random.Range(1f, 5f);

            startPos = transform.position;
            endPos = startPos + Vector3.right * ranDir * patrolTime;
            
            ChangeState(MonsterState.PATROL);
        }
    }

    public override void Patrol()
    {
        timer += Time.deltaTime;
        percent = timer / patrolTime;
        
        transform.position = Vector3.Lerp(startPos, endPos, percent);
        
        if (timer >= patrolTime)
        {
            timer = 0f;

            idleTime = Random.Range(1f, 5f);
            
            animator.SetBool("isRun", false);
            
            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Trace()
    {
        
    }

    public override void Attack()
    {
        
    }
}