using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Touched", true);
            StartCoroutine(ResetLevel());
        }
    }
    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(0);
    }
}
