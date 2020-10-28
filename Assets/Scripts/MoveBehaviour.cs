using UnityEngine;

//Использовал OnStateEnter, OnStateExit & OnStateUpdate (Задание еще не скинули, сделал пока отсебятину)
//Главное, что изучил StateMachineBehaviour!

public class MoveBehaviour : StateMachineBehaviour
{
    [SerializeField] private AnimationClip colorChange;
    [SerializeField] private GameObject prefab;

    private GameObject _cube;
    private Vector3 _currentRot;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimBullet();
        _cube = Instantiate(prefab, prefab.transform.position, Quaternion.identity);
        _currentRot = new Vector3(0f, 0f, 100f * Time.deltaTime);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _cube.transform.Rotate(_currentRot);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(_cube);
    }
    
    private void AnimBullet()
    {
        var bulletAnim = GameObject.Find("Bullet").GetComponent<Animation>();
        bulletAnim.Stop();
        bulletAnim.clip = colorChange;
        bulletAnim.Play();
    }
    
}
