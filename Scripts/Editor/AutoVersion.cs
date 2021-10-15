using System;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
#endif

namespace Visuals
{
	public class AutoVersion
	{
#if UNITY_EDITOR
		[InitializeOnLoadMethodAttribute]
		private static void OnScriptsReloaded()
		{
#if COMMAND
			PlayerSettings.companyName = "Visuals";
			PlayerSettings.runInBackground = true;
			PlayerSettings.visibleInBackground = true;
			PlayerSettings.SplashScreen.showUnityLogo = false;

			string gitRepositoryName = CommandLine.Run("git config --get remote.origin.url");
			string[] splitGitRepositoryName = gitRepositoryName.Split('/');
			gitRepositoryName = splitGitRepositoryName[splitGitRepositoryName.Length - 1].Replace(".git", "");
			gitRepositoryName = gitRepositoryName.Replace(Environment.NewLine, "");
			gitRepositoryName = gitRepositoryName.Replace("\n", "");
			PlayerSettings.productName = gitRepositoryName;
			string gitCommitsCount = CommandLine.Run("git rev-list --count HEAD");

			string[] versionArray = PlayerSettings.bundleVersion.Split('.');
			string versionMajor = string.Empty;

			if (versionArray.Length > 2)
			{
				for (int i = 0; i < versionArray.Length - 1; i++) { if (i < 2) { versionMajor += versionArray[i] + "."; } }
			}
			else if (versionArray.Length <= 2)
			{
				versionMajor = versionArray[0] + "." + versionArray[1] + ".";
			}
			else
			{
				versionMajor = "1.0.";
			}

			PlayerSettings.bundleVersion = versionMajor + gitCommitsCount;
			PlayerSettings.macOS.buildNumber = PlayerSettings.bundleVersion;
#endif		
		}
#endif
	}
}