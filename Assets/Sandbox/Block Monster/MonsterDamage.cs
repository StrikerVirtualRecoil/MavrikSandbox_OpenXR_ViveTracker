using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public Animator monsterAnim;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.transform.name == "Left Hand Cube")
            {
                monsterAnim.SetBool("Hit Left", true);
            }

            if (gameObject.transform.name == "Right Hand Cube")
            {
                monsterAnim.SetBool("Hit Right", true);
            }

            if (gameObject.transform.name == "Head Cube")
            {
                monsterAnim.SetBool("Hit Head", true);
            }
        }
        
    }


}
