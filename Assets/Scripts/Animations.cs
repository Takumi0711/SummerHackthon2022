using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    public void Jumping(float velocityY){
        animator.SetFloat("Jump", velocityY);
    }

    public void Running(bool running){
        animator.SetBool("Run", running);
    }

}