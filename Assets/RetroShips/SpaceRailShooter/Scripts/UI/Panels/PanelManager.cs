/// © 2018-2019 Kevin Foley
/// For distribution only on the Unity Asset Store
/// Terms/EULA: https://unity3d.com/legal/as_terms

using OneManEscapePlan.Scripts.UI.Panels;
using OneManEscapePlan.SpaceRailShooter.Scripts.UI.Panels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace OneManEscapePlan.SpaceRailShooter.Scripts.UI.Panels {

	/// <summary>
	/// The PanelManager is used to create instances of UI panels from prefabs. Panels could
	/// be full screens, or just popup windows/dialogs.
	/// </summary>
	/// COMPLEXITY: Beginner
	/// CONCEPTS: Panels, Inheritance
	[DisallowMultipleComponent]
	public class PanelManager : PanelManagerBase {

		protected static PanelManager current;
		public static PanelManager Current {
			get {
				return current;
			}
		}

		[SerializeField] protected GameObject controlsPanelPrefab;
		[SerializeField] protected GameObject creditsPanelPrefab;
		[SerializeField] protected GameObject settingsPanelPrefab;
		[SerializeField] protected GameObject pausePanelPrefab;
		[SerializeField] protected GameObject gameOverPanelPrefab;
		[SerializeField] protected GameObject levelCompletePanelPrefab;

		virtual protected void Start() {
			Assert.IsNotNull<GameObject>(controlsPanelPrefab, "You forgot to select the Controls Panel prefab");
			Assert.IsNotNull<GameObject>(creditsPanelPrefab, "You forgot to select the Credits Panel prefab");
			Assert.IsNotNull<GameObject>(settingsPanelPrefab, "You forgot to select the Settings Panel prefab");
			Assert.IsNotNull<GameObject>(pausePanelPrefab, "You forgot to select the Pause Panel prefab");
			Assert.IsNotNull<GameObject>(gameOverPanelPrefab, "You forgot to select the Game Over Panel prefab");
			Assert.IsNotNull<GameObject>(levelCompletePanelPrefab, "You forgot to select the Level Complete Panel prefab");

			current = this;
		}

		virtual public ControlsPanel ShowControlsPanel() {
			return getPanel<ControlsPanel>(controlsPanelPrefab);
		}
		
		virtual public CreditsPanel ShowCreditsPanel() {
			return getPanel<CreditsPanel>(creditsPanelPrefab);
		}

		virtual public SettingsPanel ShowSettingsPanel() {
			return getPanel<SettingsPanel>(settingsPanelPrefab);
		}

		virtual public PausePanel ShowPausePanel() {
			return getPanel<PausePanel>(pausePanelPrefab);
		}

		virtual public GameOverPanel ShowGameOverPanel(int score) {
			GameOverPanel panel = getPanel<GameOverPanel>(gameOverPanelPrefab);
			panel.LevelScore = score;
			return panel;
		}

		virtual public LevelCompletePanel ShowLevelCompletePanel(int score) {
			LevelCompletePanel panel = getPanel<LevelCompletePanel>(levelCompletePanelPrefab);
			panel.LevelScore = score;
			return panel;
		}

		virtual protected void OnDestroy() {
			if (current == this) current = null;
		}
	}
}
