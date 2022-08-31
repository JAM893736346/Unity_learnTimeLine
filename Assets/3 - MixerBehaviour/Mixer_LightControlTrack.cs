using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MixerExample
{
	[TrackClipType(typeof(Mixer_LightControlAsset))]
	[TrackBindingType(typeof(Light))]
	public class Mixer_LightControlTrack : TrackAsset
	{
		//显示声明为混音器
		// 创建此轨道的可播放图形时，它还将创建一个新行为PlayableBehavior （混音器），并将其连接到轨道上的所有剪辑。
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return ScriptPlayable<Mixer_LightControlMixerBehaviour>.Create(graph, inputCount);
		}
	}
}