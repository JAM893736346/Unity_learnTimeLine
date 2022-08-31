using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TrackExample
{
	[TrackClipType(typeof(Track_LightControlAsset))]
	[TrackBindingType(typeof(Light))]
	[TrackColor(0, 1, 0)]
	public class Track_LightControlTrack : TrackAsset
	{
		protected override Playable CreatePlayable(PlayableGraph graph, GameObject gameObject, TimelineClip clip)
		{
			return base.CreatePlayable(graph, gameObject, clip);
		}
		
	}
}