using UnityEngine;
using System.Collections;

public class RewardSounds : MonoBehaviour {

	//Stores the sounds for use.
	public AudioClip[] soundsofReward;
	public AudioSource rewardSource;

	//An int for shuffling through the tracks.
	public int soundNumber = 0;

	//Preventative measures from infinitely checking the variable.
	public bool gothroughClips = true;

	void Update () {

		if(gothroughClips == true)
		{
			rewardSource.playOnAwake = false;
			//Play the proper sound and loop function.
			switch (soundNumber){
				case 0:
					rewardSource.clip = soundsofReward[0];
					rewardSource.loop = true;

				print ("hhh");
					break;
				case 1:
					rewardSource.clip = soundsofReward[1];
					rewardSource.loop = false;
				print ("bbb");
					break;

				case 2:
					rewardSource.clip = soundsofReward[2];
					rewardSource.loop = false;
				print ("ccc");
					break;
			}

			gothroughClips = false;
			rewardSource.playOnAwake = true;
		}
	
	}
}
