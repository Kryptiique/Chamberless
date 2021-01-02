using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureInit : MonoBehaviour
{

	void Start() {
		InitCamTextures();
	}

	// Initializes all portal textures currently being used in the scene

	// TODO: Respond to game screen resize event to re-initialize camera textures
	void InitCamTextures() {
		var portalCams = FindObjectsOfType<PortalCamera>();
		foreach (var portalCam in portalCams) {
			Camera cam = portalCam.GetComponent<Camera>();
			var p = portalCam.transform.parent.Find("RenderPlane");
			var mat = p.GetComponent<MeshRenderer>().material;

			if (cam.targetTexture != null) {
				cam.targetTexture.Release();
			}

			cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
			mat.mainTexture = cam.targetTexture;
		}
	}
}
