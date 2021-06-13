using Rootmap.Configurator.Services;
using Microsoft.Win32;
using System;
using NLog;

namespace Rootmap.Configurator
{
  public class RegistryPathProvider : IPathProvider
  {
    private const string RootmapHklmSubKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths\ROOTMAP.exe";
    private const string RootmapCliHklmSubKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths\RootmapCLI.exe";

    private static Logger logger = LogManager.GetCurrentClassLogger();

    private readonly string _cliRootmapPath;
    private readonly string _guiRootmapPath;

    // TODO different install paths for different versions of Windows?
    public RegistryPathProvider()
    {
      var guiValue = "";
      using (var key = Registry
          .LocalMachine
          .OpenSubKey(RootmapHklmSubKey))
      {
        guiValue = key?.GetValue("")?.ToString(); // The path is the (Default) value, which is keyed by "" in the Registry.
      }
      if (!string.IsNullOrWhiteSpace(guiValue))
      {
        _guiRootmapPath = guiValue;
        logger.Info($"Per Windows Registry, ROOTMAP GUI application is located at {_guiRootmapPath}.");
      }
      else
      {
        logger.Warn("Could not locate path to ROOTMAP GUI application in the Registry.");

        // TODO Remove this development hack
        // _guiRootmapPath = @"C:\dev\code\ROOTMAP.Native\Debug\ROOTMAP.exe"; ;
        // logger.Warn($"USING TEMPORARY DEVELOPMENT PATH {_guiRootmapPath} - REMOVE BEFORE RELEASE");
      }

      var cliValue = "";
      using (var key = Registry
          .LocalMachine
          .OpenSubKey(RootmapCliHklmSubKey))
      {
        cliValue = key?.GetValue("")?.ToString(); // The path is the (Default) value, which is keyed by "" in the Registry.
      }
      if (!string.IsNullOrWhiteSpace(cliValue))
      {
        _cliRootmapPath = cliValue;
        logger.Info($"Per Windows Registry, ROOTMAP CLI application is located at {_cliRootmapPath}.");
      }
      else
      {
        logger.Warn("Could not locate path to ROOTMAP CLI application in the Registry.");

        // TODO Remove this development hack
        _cliRootmapPath = @"C:\dev\code\ROOTMAP.CLI\Debug\RootmapCLI.exe"; ;
        logger.Warn($"USING TEMPORARY DEVELOPMENT PATH {_cliRootmapPath} - REMOVE BEFORE RELEASE");
      }

    }

    public string CliRootmap => _cliRootmapPath;
    public string GuiRootmap => _guiRootmapPath;
  }
}
