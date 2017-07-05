using System.Diagnostics;

namespace AjusteProlex_WPF.Download
{
    public class FirebirdInstallation
    {
        public static void InstallFirebird(bool silentInstallation, string downloadedFile)
        {
            var installargsComponents = "/COMPONENTS=" + "\"ServerComponent,DevAdminComponent,ClientComponent\"";
            var installargsTasks = " /TASKS=" + "\"UseSuperServerTask,UseServiceTask,AutoStartTask,MenuGroupTask,CopyFbClientToSysTask,CopyFbClientAsGds32Task,EnableLegacyClientAuth\"";
            var installargsSecurity = " /SYSDBAPASSWORD=masterkey";
            var installargsSilent = " /FORCE /SILENT /SP-";

            Process process = new Process();
            process.StartInfo.FileName = downloadedFile;
            process.StartInfo.Arguments = installargsComponents;
            process.StartInfo.Arguments += installargsTasks;
            process.StartInfo.Arguments += installargsSecurity;
            if (silentInstallation)
                process.StartInfo.Arguments += installargsSilent;

            process.Start();
        }
    }
}
