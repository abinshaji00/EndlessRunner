using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offSet;
    private Vector3 moveVector;

    private float transition = 0f;
    private float animationDuration = 2f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offSet= transform.position-lookAt.position;
    }
    void Update()
    {
        moveVector = lookAt.position + offSet;
        moveVector.x = 0f;
        moveVector.y= Mathf.Clamp(moveVector.y, 3, 5);
        if (transition > 1f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position+Vector3.up);
        }
        
    }
}
