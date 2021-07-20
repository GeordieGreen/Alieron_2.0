/// © 2018-2019 Kevin Foley
/// For distribution only on the Unity Asset Store
/// Terms/EULA: https://unity3d.com/legal/as_terms

using OneManEscapePlan.Scripts.Events;
using OneManEscapePlan.Scripts.Gameplay.DamageSystem;
using OneManEscapePlan.Scripts.Properties;
using OneManEscapePlan.SpaceRailShooter.Scripts.Gameplay.ScoringSystem;
using OneManEscapePlan.SpaceRailShooter.Scripts.UI.Panels;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace OneManEscapePlan.SpaceRailShooter.Scripts.Gameplay {

	[System.Serializable]
	public class PlayerEvent : UnityEvent<Player> { }

	[System.Serializable]
	public class PlayerIntEvent : UnityEvent<Player, int> { }

	/// <summary>
	/// The Player class manages general properties of a player, such as Lives and Score, that don't belong
	/// on the player's Spacecraft. 
	/// </summary>
	/// COMPLEXITY: Beginner
	/// CONCEPTS: UnityEvents
	[DisallowMultipleComponent]
	public class Player : MonoBehaviour, IScore, IReceivePoints {

		[Tooltip("The player's current spacecraft")]
		[DrawConnections(ColorName.PulsingBlue)]
		[SerializeField] protected PlayerSpacecraft spacecraft;

		[Tooltip("The player's current lives")]
		[SerializeField] protected IntProperty lives = new IntProperty(3);
		[Tooltip("The maximum number of lives that the player can have")]
		[SerializeField] protected int maxLives = 10;
		[Tooltip("The player's current score")]
		[SerializeField] protected IntProperty score = new IntProperty(0);

		[Tooltip("This event is invoked when the player's score changes")]
		[DrawConnections(ColorName.Magenta)]
		[SerializeField] protected PlayerIntEvent scoreChangedEvent = new PlayerIntEvent();
		public PlayerIntEvent ScoreChangedEvent { get { return scoreChangedEvent; } }

		[Tooltip("This event is invoked when the player gains a life")]
		[DrawConnections(ColorName.Green)]
		[SerializeField] protected PlayerIntEvent gainedLifeEvent = new PlayerIntEvent();
		public PlayerIntEvent GainedLifeEvent { get { return gainedLifeEvent; } }

		[Tooltip("This event is invoked when the player loses a life")]
		[DrawConnections(ColorName.Red)]
		[SerializeField] protected PlayerIntEvent lostLifeEvent = new PlayerIntEvent();
		public PlayerIntEvent LostLifeEvent { get { return lostLifeEvent; } }

		[Tooltip("This event is invoked when the player runs out of lives")]
		[DrawConnections(ColorName.Gray)]
		[SerializeField] protected PlayerEvent gameOverEvent = new PlayerEvent();
		public PlayerEvent GameOverEvent { get { return gameOverEvent; } }

		[Tooltip("This event is invoked when the player respawns")]
		[DrawConnections(ColorName.Violet)]
		[SerializeField] protected Vector3Event respawnEvent = new Vector3Event();
		public Vector3Event RespawnEvent { get { return respawnEvent; } }

		virtual protected void Awake() {
			if (spacecraft != null) {
				Spacecraft = spacecraft;
			}
		}

		/// <summary>
		/// The Player's current number of lives
		/// </summary>
		public int Lives {
			get {
				return lives.Value;
			}

			set {
				Assert.IsFalse(lives < 0, "Tried to give a Player negative lives");

				int oldLives = lives.Value;
				int newLives = value;
				if (newLives > maxLives) newLives = maxLives;
				lives.Value = newLives;
				if (lives < oldLives) lostLifeEvent.Invoke(this, lives.Value);
				else if (lives > oldLives) gainedLifeEvent.Invoke(this, lives.Value);
				if (oldLives > 0 && lives <= 0) gameOverEvent.Invoke(this);
			}
		}

		/// <summary>
		/// The maximum number of lives the player can have
		/// </summary>
		public int MaxLives {
			get {
				return maxLives;
			}

			set {
				Assert.IsFalse(value < 1, "MaxLives must be a positive value");
				maxLives = value;
				if (lives > maxLives) Lives = MaxLives;
			}
		}

		/// <summary>
		/// The player's current score. Constrained to non-negative values.
		/// </summary>
		public int Score {
			get {
				return score;
			}

			set {
				int oldScore = score;
				int newScore = value;
				if (newScore < 0) newScore = 0;
				score.Value = newScore;
				if (oldScore != score) scoreChangedEvent.Invoke(this, score);
			}
		}

		/// <summary>
		/// Add the given number of points to the Player's score
		/// </summary>
		/// <param name="points">The number of points to add</param>
		public void AddPoints(int points) {
			Score += points;
		}

		virtual public void CompleteLevel() {
			PanelManager pm = PanelManager.Current;
			Assert.IsNotNull<PanelManager>(pm);
			pm.ShowLevelCompletePanel(score);
		}

		virtual public PlayerSpacecraft Spacecraft {
			get {
				return spacecraft;
			}
			set {
				//remove events from previous spacecraft, if applicable
				if (spacecraft != null) {
					IHealth health = spacecraft.GetComponent<IHealth>();
					if (health != null)	health.DeathEvent.RemoveListener(onDeath);
					spacecraft.GainPointsEvent.RemoveListener(AddPoints);
				}

				spacecraft = value;

				//add events to new spacecraft, if applicable
				if (spacecraft != null) {
					IHealth health = spacecraft.GetComponent<IHealth>();
					Assert.IsNotNull<IHealth>(health);
					health.DeathEvent.AddListener(onDeath);
					spacecraft.GainPointsEvent.AddListener(AddPoints);
				}
			}
		}

		virtual protected void onDeath(IHealth health) {
			Lives--;
			
			if (Lives > 0) {
				Transform transform = health.GetComponent<Transform>();
				Vector3 position = transform.position;
				respawnEvent.Invoke(position);
			} else {
				PanelManager pm = PanelManager.Current;
				Assert.IsNotNull<PanelManager>(pm);
				pm.ShowGameOverPanel(score.Value);
			}
		}
	}

}
