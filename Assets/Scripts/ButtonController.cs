using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Color = Animator.StringToHash("Color");
    private static readonly int Transform = Animator.StringToHash("Transform");

    private void Start()
    {
        StartCoroutine(UpdateParam());
    }

    private IEnumerator UpdateParam()
    {
        yield return new WaitForSeconds(6f);
        Debug.Log("Update");
        animator.SetFloat(Color, GetRandomNum());
        animator.SetFloat(Transform,GetRandomNum());
        StartCoroutine(UpdateParam());
    }
    
    private float GetRandomNum()
    {
        return Random.Range(0, 100)/100f;
    }
}
