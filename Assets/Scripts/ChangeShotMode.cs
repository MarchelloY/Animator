using UnityEngine;
using UnityEngine.UI;

public class ChangeShotMode : MonoBehaviour
{
    [SerializeField] private Button btn1;
    [SerializeField] private Button btn2;
    [SerializeField] private AnimationClip move;
    [SerializeField] private AnimationClip moveUp;
    [SerializeField] private Animator animator;
    
    private AnimatorOverrideController _animatorOverrideController;

    private void Start()
    {
        btn1.onClick.AddListener(ClickButton1);
        btn2.onClick.AddListener(ClickButton2);
        _animatorOverrideController = new AnimatorOverrideController (animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = _animatorOverrideController;
    }

    private void ClickButton1()
    {
        animator.Rebind();
        _animatorOverrideController["Move"] = move;
    }
    
    private void ClickButton2()
    {
        animator.Rebind();
        _animatorOverrideController["Move"] = moveUp;
    }
    
}
