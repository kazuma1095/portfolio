using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSpeed : MonoBehaviour
{
    [Header("�@�֎Ԃ�Controller")]
    // �ړ����x������Ă���p
    public LocomotiveContoroller LC;

    // �A�j���[�V�����R���|�[�l���g
    private Animator p_Animator;

    // �A�j���[�V�����̕������x�̒����p�����[�^��
    private const string ps_Speed = "Speed";

    void Start()
    {
        // �A�j���[�^�[�̎Q�Ƃ��擾����
        p_Animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        // �A�j���[�V�����̑��x��[WalkSpeed]�p�����[�^�ɐݒ肷��
        p_Animator.SetFloat(ps_Speed, LC.speed * LC.animSpeed);
    }
}
