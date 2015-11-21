using UnityEngine;
using System.Collections;

namespace GameFoundations
{
	public class AudioQueue3D : MonoBehaviour
	{
		public int maxPending = 30;

		private IAudioEvent3D[] _pending;
		
		private int _head;
		private int _tail;

		void OnEnable ()
		{
			_head = _tail = 0;
			_pending = new IAudioEvent3D [maxPending];
			
			Events.instance.AddListener<AudioEvent3D> (OnAudio);
		}
		
		void OnDisable ()
		{
			Events.instance.RemoveListener<AudioEvent3D> (OnAudio);
		}
		
		void Update ()
		{
			if (_head == _tail)
				return;
			
			Debug.Log ("Playing: " + _pending [_head].Audio.name + " at position: " + _pending [_head].Position);
			
			AudioSource.PlayClipAtPoint (_pending [_head].Audio, _pending [_head].Position);
			
			_head = (_head + 1) % maxPending;
		}
		
		void OnAudio (IAudioEvent3D e)
		{
			for (int i = _head; i != _tail; i = (i+1) % maxPending) {
				Debug.Log (i + ": " + _pending [i].Audio.name);
				if (_pending [i].Audio.name.Equals (e.Audio.name)) {
					return;
				}
			}
			
			_pending [_tail] = e;
			_tail = (_tail + 1) % maxPending;
		}
		
	}
}
