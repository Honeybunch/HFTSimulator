using UnityEngine;
using System.Collections;

public class MoveToScreen : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;

    public Vector3 AtScreenPos;
    public Vector3 AtScreenRot;

    public float MoveSpeed = 1.0f;
    public float RotSpeed = 2.0f;

    private InitializeGameCanvas gameCanvas;

    public void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;

        gameCanvas = GetComponent<InitializeGameCanvas>();
    }

    public void Activate()
    {
        StartCoroutine(MoveTowards());
    }

    public void Deactiveate()
    {
        StartCoroutine(MoveAway());
    }

    private IEnumerator MoveTowards()
    {
        float moveStep = MoveSpeed * Time.deltaTime;
        float rotStep = RotSpeed * Time.deltaTime;

        bool moveDone = false;
        bool rotDone = false;

        Quaternion newRot = Quaternion.Euler(AtScreenRot);

        while (!moveDone || !rotDone)
        {
            if(!moveDone)
                transform.position = Vector3.MoveTowards(transform.position, AtScreenPos, moveStep);
            if(!rotDone)
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotStep);

            if (transform.position == AtScreenPos)
                moveDone = true;
            if (transform.rotation == newRot)
                rotDone = true;
            
            yield return null;
        }

        gameCanvas.Activate();

        yield return null;
    }

    private IEnumerator MoveAway()
    {
        float moveStep = MoveSpeed * Time.deltaTime;
        float rotStep = RotSpeed * Time.deltaTime;

        bool moveDone = false;
        bool rotDone = false;

        while (!moveDone || !rotDone)
        {
            if (!moveDone)
                transform.position = Vector3.MoveTowards(transform.position, startPos, moveStep);
            if (!rotDone)
                transform.rotation = Quaternion.Slerp(transform.rotation, startRot, rotStep);

            if (transform.position == startPos)
                moveDone = true;
            if (transform.rotation == startRot)
                rotDone = true;

            yield return null;
        }

        yield return null;
    }
}
