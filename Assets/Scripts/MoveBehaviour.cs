using UnityEngine;

//Использовал OnStateEnter, OnStateExit & OnStateUpdate (Задание еще не скинули, сделал пока отсебятину)
//Главное, что изучил StateMachineBehaviour!

public class MoveBehaviour : StateMachineBehaviour
{
    [SerializeField] private AnimationClip colorChange;
    [SerializeField] private GameObject prefabCube;

    private GameObject _cube;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimBullet();
        _cube = Instantiate(prefabCube, prefabCube.transform.position, Quaternion.identity);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _cube.transform.Rotate(new Vector3(0f, 0f, 100f * Time.deltaTime));
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
