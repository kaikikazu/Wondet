using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face2 : Photon.MonoBehaviour {
	public GameObject face;
	SkinnedMeshRenderer skinnedMeshRenderer;
	public float A2,I2,U2,E2,O2;
	private int A_mouth,I_mouth,U_mouth,E_mouth,O_mouth;

	// Use this for initialization
	void Start () {
		face = GameObject.Find("MTH_DEF");
		skinnedMeshRenderer = face.GetComponent<SkinnedMeshRenderer> ();
		A_mouth = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("blendShape1.MTH_A");
		I_mouth = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("blendShape1.MTH_I");
		U_mouth = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("blendShape1.MTH_U");
		E_mouth = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("blendShape1.MTH_E");
		O_mouth = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("blendShape1.MTH_O");
	}

	// Update is called once per frame
	void Update () {
		skinnedMeshRenderer.SetBlendShapeWeight(A_mouth,A2);
		skinnedMeshRenderer.SetBlendShapeWeight(I_mouth,I2);
		skinnedMeshRenderer.SetBlendShapeWeight (U_mouth, U2);
		skinnedMeshRenderer.SetBlendShapeWeight (E_mouth, E2);
		skinnedMeshRenderer.SetBlendShapeWeight (O_mouth, O2);
		A2 = skinnedMeshRenderer.GetBlendShapeWeight (A_mouth);
		I2 = skinnedMeshRenderer.GetBlendShapeWeight (I_mouth);
		U2 = skinnedMeshRenderer.GetBlendShapeWeight (U_mouth);
		E2 = skinnedMeshRenderer.GetBlendShapeWeight (E_mouth);
		O2 = skinnedMeshRenderer.GetBlendShapeWeight (O_mouth);

	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			//データの送信
			stream.SendNext(A2);
			stream.SendNext(I2);
			stream.SendNext (U2);
			stream.SendNext(E2);
			stream.SendNext(O2);
		} else {
			//データの受信
			this.A2 = (int)stream.ReceiveNext();
			this.I2 = (int)stream.ReceiveNext();
			this.U2 = (int)stream.ReceiveNext();
			this.E2 = (int)stream.ReceiveNext();
			this.O2 = (int)stream.ReceiveNext();
		}
	}
}
