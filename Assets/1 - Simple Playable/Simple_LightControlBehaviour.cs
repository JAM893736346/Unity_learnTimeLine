using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.SocialPlatforms;

namespace Simple
{
	public class Simple_LightControlBehaviour : PlayableBehaviour
	{
		public Light light;
		public Color color;
		public float intensity;

		public float Range;

		private AnimationMixerPlayable mixerPlayable;
		
		public override void PrepareData(Playable playable, FrameData info)
		{
			base.PrepareData(playable, info);
			Debug.Log(info.weight);
			Debug.Log(playable.GetDuration());
		}

		public override void OnBehaviourPlay(Playable playable, FrameData info)
		{
			base.OnBehaviourPlay(playable, info);
			Debug.Log(info.weight);
			Debug.Log(playable.GetDuration());
		}
		//面板上包含的所有片段默认开始
		public override void OnGraphStart(Playable playable)
		{
			base.OnGraphStart(playable);
			Debug.Log(playable.GetDuration());
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			if (light != null)
			{
				light.color = color;
				light.intensity = intensity;
				light.range = Range;
			}
			// float blend = Mathf.PingPong((float)playable.GetTime(), 1.0f);
			//
			// mixerPlayable.SetInputWeight(0, blend);
			// mixerPlayable.SetInputWeight(1, 1.0f - blend);

			base.PrepareFrame(playable, info);
		}
	}
}