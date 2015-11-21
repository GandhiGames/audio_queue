using UnityEngine;
using System.Collections;

namespace GameFoundations
{
	public class AudioEvent2D : GameEvent, IAudioEvent2D
	{
		private AudioClip audioClip;
		public AudioClip audio { get {
				return audioClip;
			} }
	
		public AudioEvent2D (AudioClip audioClip)
		{
			this.audioClip = audioClip;
		}
	}
}
