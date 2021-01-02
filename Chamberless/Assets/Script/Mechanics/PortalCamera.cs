using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	Transform playerCamera;
	Transform portal;
	Transform targetPortal;

	private void Start() {
		this.playerCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0].transform;
		var p = gameObject.transform.parent.GetComponent<Portal>();
		this.portal = p.transform.Find("RenderPlane");
		if (p.Target != null) {
			targetPortal = p.Target.transform.Find("RenderPlane").transform;
		}

	}

	// Update is called once per frame
	void Update () {
		if (targetPortal == null) return;

		Vector3 playerOffsetFromPortal = playerCamera.position - targetPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, targetPortal.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}