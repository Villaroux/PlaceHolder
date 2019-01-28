using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum MovementType
    {
        Straight,
        RandomStraight,
        Sine,
        RandomSine
    }
    public MovementType moveType;

    public float speed;
    public float attackRange;
    public float swirlRange;
    public float sineCycleSpeed;
    public float sineAmplitude;
    public LayerMask barrierMask;
    public LayerMask wallsMask;
    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void Start()
    {
        //Get RandomDirection times speed
        //rb.velocity = new Vector2(Random.Range(0.1f,1.0f), Random.Range(-1.0f,1.0f)).normalized * speed;
    }
    private void FixedUpdate()
    {

        switch (moveType)
        {
            case (MovementType.Straight):
                StraightMotion();
                break;
            case (MovementType.Sine):
                SineMotion();
                break;
            case (MovementType.RandomStraight):
                RandomStraight();
                break;
            case (MovementType.RandomSine):
                RandomSine();
                break;
            default:
                StraightMotion();
                break;
        }
    }

    void StraightMotion()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, attackRange, barrierMask);

        if (!hitInfo)
        {
            //Debug.DrawRay(transform.position, Vector3.right * attackRange);
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            //Start Attacking Barrier/Player
            rb.velocity = Vector2.zero;
        }

    }
    void SineMotion()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, attackRange, barrierMask);

        if (!hitInfo)
        {
            Vector2 currV = rb.velocity;
            currV.x = speed;
            currV.y = Mathf.Sin(sineCycleSpeed * Time.time) * sineAmplitude;
            rb.velocity = currV;

        }
        else
        {
            //Start Attacking Barrier/Player
            rb.velocity = Vector2.zero;
        }
    }
    void RandomStraight()
    {

        //Debug.DrawRay(transform.position, rb.velocity.normalized*swirlRange, Color.green);                    //This is wallHit DebugLine
        //Debug.DrawRay(transform.position, Vector2.right * attackRange, Color.red);                            //This is barrierHit DebugLine

        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, rb.velocity, swirlRange, wallsMask);

        RaycastHit2D barrierHit = Physics2D.Raycast(transform.position, Vector2.right, attackRange, barrierMask);


        if (!barrierHit)
        {
            //Continue to move
            if (wallHit)
            {

                //Wall hit get new direction
                Vector2 currDir = rb.velocity.normalized;

                currDir.x = Random.Range(0.1f, 1.0f);
                if (currDir.y < 0)
                {
                    //Hit bottom wall
                    currDir.y = Random.Range(0.0f, 1.0f);
                }
                else
                {
                    currDir.y = Random.Range(-1.0f, 0.0f);
                }

                swirlRange = Random.Range(.8f, 3.0f);

                currDir.Normalize();

                rb.velocity = currDir * speed;
            }
            else if (rb.velocity.magnitude < 0.1f)
            {
                //After destroying a barrier go straight for another
                rb.velocity = Vector2.right * speed;
            }
        }
        else
        {
            //Start attack
            rb.velocity = Vector2.zero;
        }
    }
    void RandomSine()
    {
        //Debug.DrawRay(transform.position, rb.velocity.normalized*swirlRange, Color.green);                    //This is wallHit DebugLine
        //Debug.DrawRay(transform.position, Vector2.right * attackRange, Color.red);                            //This is barrierHit DebugLine

        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, rb.velocity, swirlRange, wallsMask);

        RaycastHit2D barrierHit = Physics2D.Raycast(transform.position, Vector2.right, attackRange, barrierMask);


        if (!barrierHit) // Haven't reached the barrier yet so Continue to move
        {
            if (wallHit)
            {

                //Wall hit get new direction
                Vector2 currDir = rb.velocity.normalized;

                currDir += Vector2.right;

                currDir.Normalize();

                rb.velocity = currDir * speed;
            }
            else if (rb.velocity.magnitude < 0.01f) // Starting/Restarting to move
            {
                Vector2 currDir;
                //Randomize Values
                currDir.x = Random.Range(0.1f, 1.0f);
                sineCycleSpeed = Random.Range(0.1f, 3.0f);
                sineAmplitude = Random.Range(0.0f, 5.0f);
                speed = Random.Range(2.0f, 5.0f);

                currDir.y = Mathf.Sin(sineCycleSpeed * Time.time) * sineAmplitude;
                //Normalize 
                currDir.Normalize();

                //Commit 
                rb.velocity = currDir * speed;
            }
            else
            {
                Vector2 CurrDir = rb.velocity;
                CurrDir.y = Mathf.Sin(sineCycleSpeed * Time.time) * sineAmplitude;

                CurrDir.Normalize();

                rb.velocity = CurrDir * speed;
            }
        }
        else // Reached the barrier
        {
            //Start attack
            rb.velocity = Vector2.zero;
        }
    }
}
