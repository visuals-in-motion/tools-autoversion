using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
using System.Linq;

namespace Visuals
{
#if UNITY_EDITOR_WIN
    [InitializeOnLoad]
    public class InstallDependency
    {
        static InstallDependency()
        {
            string manifestPath = Path.GetFullPath("Packages/manifest.json");
            string commandPackage = "    \"ru.visuals.command\": \"https://github.com/visuals-in-motion/tools-command.git\",";

            List<string> file = File.ReadAllLines(manifestPath).ToList();

            if (!file.Contains(commandPackage))
            {
                file.Insert(2, commandPackage);
                File.WriteAllLines(manifestPath, file);
            }
        }
    }
#endif
}