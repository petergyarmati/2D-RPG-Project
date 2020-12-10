using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject sword;

    private Animator _animator;
    private Vector2 _direction;
    
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        if (vertical != 0f)
        {
            transform.Translate(0, speed * vertical * Time.deltaTime, 0);
            _direction = new Vector2(0, vertical);
        }
        else if (horizontal != 0f)
        {
            transform.Translate(speed * horizontal * Time.deltaTime, 0, 0);
            _direction = new Vector2(horizontal, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
            Attack();
        
        UpdateAnimator("horizontal", horizontal);
        UpdateAnimator("vertical", vertical);
    }

    private void UpdateAnimator(string direction, float value)
    {
        _animator.SetFloat(direction, value);
    }

    void Attack()
    {
        GameObject newSword = Instantiate(sword, transform.position, sword.transform.rotation);

        if (_direction.x != 0)
        {
            newSword.transform.Rotate(0, 0, 90 * -Mathf.Round(_direction.x));
            newSword.GetComponent<Sword>().AddTrust(new Vector2(_direction.x, 0));
        }
        else if(_direction.y != 0)
        {
            newSword.transform.Rotate(0, 0, Mathf.Round(_direction.y) > 0 ? 0 : 180);
            newSword.GetComponent<Sword>().AddTrust(new Vector2(0, _direction.y));
        }
        else
        {
            newSword.transform.Rotate(0, 0, 180);
            newSword.GetComponent<Sword>().AddTrust(Vector2.down);
        }
    }
}
