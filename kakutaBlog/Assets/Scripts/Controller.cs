using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controller : MonoBehaviour {
    [SerializeField] float runspeed = 3f; //���f���̈ړ��Ɋւ���ϐ���`
    [SerializeField] float rotateSpeed = 10f;
    private Animator animator; //�A�j���[�^�APhotonView�Ɋւ���ϐ�
    void Start() {
        animator = gameObject.GetComponent<Animator>(); //animator�̎擾
    }
    void Update() { 
        //�e��L�[����ƃA�j���[�V��������
        if (Input.GetKeyDown(KeyCode.Space) &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("jump") &&
            !animator.IsInTransition(0)) { //Space�L�[�ŃW�����v
            animator.SetTrigger("jump");
        }
        if (Input.GetKey(KeyCode.W)) { //W�L�[�őO�i
            animator.SetFloat("speed", runspeed);
            animator.transform.position +=
                animator.transform.forward * Time.deltaTime * runspeed;
        }
        if (Input.GetKeyUp(KeyCode.W)) { //�����I�������X�g�b�v
            animator.SetFloat("speed", 0f);
        }
        if (Input.GetKey(KeyCode.A)) { //A�L�[�ō���]
            animator.transform.Rotate(0f, -0.10f * rotateSpeed, 0f);
        }
        if (Input.GetKey(KeyCode.D)) { //D�L�[�ŉE��]
            animator.transform.Rotate(0f, 0.10f * rotateSpeed, 0f);
        }
    }
}