using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LightControlClip : PlayableAsset, ITimelineClipAsset
{
    // 将抽象函数中的接收的第一个参数以及添加的LightControlBehaviour类型对象一起传入并调用ScriptPlayable.Create函数，从而得到一个跟LightControlBehaviour类型的行为相绑定的可播放资源类型对象。
    public LightControlBehaviour template = new LightControlBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LightControlBehaviour>.Create (graph, template);
        return playable;    }
}
