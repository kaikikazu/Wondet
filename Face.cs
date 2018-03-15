using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Photon.MonoBehaviour {
	public GameObject face;
	SkinnedMeshRenderer skinnedMeshRenderer;
	public float A,I,U,E,O;
	public int A_mouth,I_mouth,U_mouth,E_mouth,O_mouth;

	// Use this for initialization
	//母音のブレンドシェイプの値を取得。値はOVRlipSyncによって自動で変動している。
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
	//母音のブレンドシェイプの値を設定。別アプリケーションで動いてるキャラにlipSyncを反映させるために手動でつける必要がある
	void Update () {
		skinnedMeshRenderer.SetBlendShapeWeight(A_mouth,A);
		skinnedMeshRenderer.SetBlendShapeWeight(I_mouth,I);
		skinnedMeshRenderer.SetBlendShapeWeight (U_mouth, U);
		skinnedMeshRenderer.SetBlendShapeWeight (E_mouth, E);
		skinnedMeshRenderer.SetBlendShapeWeight (O_mouth, O);
		A = skinnedMeshRenderer.GetBlendShapeWeight (A_mouth);
		I = skinnedMeshRenderer.GetBlendShapeWeight (I_mouth);
		U = skinnedMeshRenderer.GetBlendShapeWeight (U_mouth);
		E = skinnedMeshRenderer.GetBlendShapeWeight (E_mouth);
		O = skinnedMeshRenderer.GetBlendShapeWeight (O_mouth);

	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			//データの送信
			stream.SendNext(A);
			stream.SendNext(I);
			stream.SendNext (U);
			stream.SendNext(E);
			stream.SendNext(O);
		} else {
			//データの受信
			this.A = (int)stream.ReceiveNext();
			this.I = (int)stream.ReceiveNext();
			this.U = (int)stream.ReceiveNext();
			this.E = (int)stream.ReceiveNext();
			this.O = (int)stream.ReceiveNext();
		}
	}
}
