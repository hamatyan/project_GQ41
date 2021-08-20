using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
	public List<Parameter> nodeObj = new List<Parameter>(); //全ノード
	int node_cnt;   //ノードの数


	public Text nodeText;
	public Text treeText;

	public struct Node
	{
		public int[] data;//nodeの値
		public int[] root;//親の値
		public int[] left;//左の値
		public int[] right;//右の値
	}

	int[] sznode;//ノード格納用
	Node r_node;
	int now_node_namber;    //現在触っているノード
	public Vector3 textpos;

	private void Awake()
	{
		node_cnt = nodeObj.Count;
		sznode = new int[node_cnt];
		now_node_namber = 0;
		r_node.data = new int[node_cnt];
		r_node.root = new int[node_cnt];
		r_node.right = new int[node_cnt];
		r_node.left = new int[node_cnt];

		textpos = treeText.transform.position;
		textpos.y = 10.0f;

		for (int i = 0; i < node_cnt; i++)
		{
			sznode[i] = nodeObj[i].nodenamber;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		DrawText();
		MakeTree(r_node);

	}

    // Update is called once per frame
    void Update()
    {
		//ツリー作成
		//比較

		//Debug.DrawLine(nodeObj[r_node.data[0]].gameObject.transform.position,
		//		nodeObj[r_node.data[1]].gameObject.transform.position, Color.red);
	}

	/// <summary>
	/// ツリー構築
	/// </summary>
	/// <param name="data"></param>
	void MakeTree(Node node)
	{
		if (nodeObj.Count - 1 <= now_node_namber) return;

		int n = now_node_namber;
		if (node.root[n] <= sznode[n + 1])	//新データと親との比較
		{
			//dataがない場合＝子供がいない
			if(node.data[n] == 0)
			{
				r_node.data[n] = sznode[n];
			}

			//2<5, 
			if (node.data[n] < sznode[n + 1])//その親の子供と新データとの比較
			{
				r_node.right[n] = sznode[n + 1];
				r_node.root[n] = r_node.data[n];
				r_node.data[n] = r_node.right[n];
				now_node_namber++;
				DrawTree(node.root[n]);
				MakeTree(r_node);
			}
			else
			{
				r_node.left[n] = sznode[n + 1];
				r_node.root[n] = r_node.data[n];
				r_node.data[n] = r_node.left[n];
				now_node_namber++;
				DrawTree(node.root[n]);
				MakeTree(r_node);
			}
		}
	}

	void Find()
	{

	}

	void DrawText()
	{
		nodeText.text = "{";
		for (int i = 0; i < node_cnt; i++)
		{
			nodeText.text = nodeText.text  +  sznode[i] + ",";
		}
		nodeText.text = nodeText.text + "}";
	}

	void DrawTree(int n)
	{
		
		treeText.transform.position += textpos;
		treeText.text = treeText.text + n.ToString() + ",";


	}

	void Swap(int a, int b)
	{
		int w;

		w = a;
		a = b;
		b = w;
	}
}
