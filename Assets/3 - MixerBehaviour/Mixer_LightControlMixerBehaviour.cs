using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MixerExample
{
	public class Mixer_LightControlMixerBehaviour : PlayableBehaviour
	{
		// NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			Light trackBinding = playerData as Light;
			float finalIntensity = 0f;
			Color finalColor = Color.black;

			if (!trackBinding)
				return;

			int inputCount = playable.GetInputCount (); //get the number of all clips on this track
			
			for (int i = 0; i < inputCount; i++)
			{
				// 返回给定输入端口索引处连接的 Playable 的权重。
				float inputWeight = playable.GetInputWeight(i);//获得当前时刻每个片段的权重
				
				//可以看出来，要想创建一个ScriptPlayable，首先需要定义这个脚本Playable的行为模式，
				//它的行为模式用PlayableBehaviour类的对象来表示，在创建完该对象之后，就可以创建实际的ScriptPlayable对象了。
				ScriptPlayable<Mixer_LightControlBehaviour> inputPlayable = (ScriptPlayable<Mixer_LightControlBehaviour>)playable.GetInput(i);
				Mixer_LightControlBehaviour input = inputPlayable.GetBehaviour();//获得当前所有片段
				Debug.Log(input);
				//Debug.Log(input.color);
				// 混音器可以访问轨道上存在的所有剪辑。在这种情况下，您需要读取当前参与混合的所有剪辑的强度和颜色值，
				// 因此您需要使用 for 循环循环遍历它们。在每个周期中，您可以访问输入 （GetInput（i）） 并使用每个剪辑的权重 （GetInputWeight（i）） 来构建最终值，以获取该剪辑对混合的贡献。
				//
				// 所以，假设你有两个剪辑混合：一个是贡献红色，另一个是贡献白色。当混合经过四分之一时，颜色为 0.25 * Color.red + 0.75 * Color.white，这会导致红色略微褪色。
				// Use the above variables to process each frame of this playable.
				finalIntensity += input.intensity * inputWeight;
				finalColor += input.color * inputWeight;
			}

			//assign the result to the bound object
			trackBinding.intensity = finalIntensity;
			trackBinding.color = finalColor;
		}
	}
}