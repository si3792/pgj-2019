using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
	public float clipLeft, clipRight;
	public float clipUp, clipDown;
    private GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

			// Apply left and right limits
			var clampedX = Mathf.Clamp(transform.position.x, clipLeft, clipRight);
			var clampedY = Mathf.Clamp(transform.position.y, clipDown, clipUp);
			transform.position = new Vector3 (clampedX, clampedY, transform.position.z);
        }
    }

}
