using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace OneManEscapePlan.SpaceRailShooter.Scripts.Gameplay {

	public class PlayerContainer : MonoBehaviour {

		public int x = 0;
		public int y = 0;
		public int z = 6;

		public GameObject speedLines;

		[SerializeField] private PlayerSpacecraft playerSpacecraft;
		Vector3 speed;

		private void Start()
        {
			speedLines.GetComponent<ParticleSystem>().Stop();
		}

        private void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
				z = 15;
				speedLines.GetComponent<ParticleSystem>().Play();
			}

            else if (UnityEngine.Input.GetKey(KeyCode.LeftControl))
            {
				z = 0;
            }

			else if (UnityEngine.Input.GetButton("Break"))
			{
				z = 0;
				Debug.Log("Breaking");
			}

			else if (UnityEngine.Input.GetButton("Boost"))
            {
				z = 15;
				speedLines.GetComponent<ParticleSystem>().Play();
			}

            else
            {
				z = 8;
				speedLines.GetComponent<ParticleSystem>().Stop();
			}
			speed = new Vector3(x, y, z);
		}

        void FixedUpdate() {
			if (playerSpacecraft != null) {
				transform.Translate(speed * Time.deltaTime, Space.Self);
			}
		}

		public PlayerSpacecraft PlayerSpacecraft {
			get {
				return playerSpacecraft;
			}

			set {
				playerSpacecraft = value;
			}
		}
	}

}
