using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public Animator m_anim;
    public bool m_walking;
    public bool m_attack;

    public Transform target;

    public int speed;

    public int attackCount;


    // Start is called before the first frame update
    void Start()
    {
        m_walking = true;
        m_attack = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (m_walking)
        {
            m_anim.SetBool("Walking", true);
        }
        else
        {
            m_anim.SetBool("Walking", false);
        }

        if (m_attack)
        {
            Attack();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Monster Target")
        {
            m_attack = true;
            m_walking = false;
            
            m_anim.SetBool("Angry", true);
        }
  
    }

    private void Attack()
    {

        if(attackCount > 2)
        {
            attackCount = 0;
        }


        if (attackCount == 0)
        {
            m_anim.SetBool("Attack Right", true);

            m_anim.SetBool("Attack Left", false);
            m_anim.SetBool("Attack Center", false);

        }
        else if (attackCount == 1)
        {
            m_anim.SetBool("Attack Left", true);

            m_anim.SetBool("Attack Right", false);
            m_anim.SetBool("Attack Center", false);

        }
        else if (attackCount == 2)
        {
            m_anim.SetBool("Attack Center", true);

            m_anim.SetBool("Attack Left", false);
            m_anim.SetBool("Attack Right", false);

        }

    }

    public void AttackCountInc()
    {
        attackCount++;
    }
}
