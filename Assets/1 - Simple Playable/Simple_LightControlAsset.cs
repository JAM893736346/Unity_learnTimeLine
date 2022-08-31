using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Simple
{
	//第一步 : 定义 继承 PlayerableBehavior的脚本 主要控制数据的变化操作
	//第二步 ： 定义 继承 PlayableAsset的脚本 主要控制面板的显示内容 
	//第三步： 实现对应的方法 比如 Processframe就是每次变化对数值做什么
	//                   CreatePlayable c创建片段对象
	
	//面板上的数据
	public class Simple_LightControlAsset : PlayableAsset
	{
		public ExposedReference<Light> light;
		public Color color = Color.white;
		public float intensity = 1f;
		public float Range = 10f;
		
		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<Simple_LightControlBehaviour>.Create(graph);

			var behaviour = playable.GetBehaviour();
			//将实例引用传进去
			behaviour.light = light.Resolve(graph.GetResolver());
			behaviour.color = color;
			behaviour.intensity = intensity;
			behaviour.Range = Range;
			return playable;
		}
		
	}
}