using System;
using static System.SystemInterface;
using static Winapi.Shellapi.ShellapiImplementation;
using static Winapi.Shellapi.ShellapiInterface;

namespace Winapi
{

namespace Shellapi
{

/*
  D2CSharp Runtime Library (RTL)
  Minimal declaration-oriented Winapi.ShellApi mock for DelphiSudoku.
  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class ShellapiInterface
{
	public const int SW_SHOWNORMAL = 1;

            public static int ShellExecute(int hWnd, string Operation, PChar FileName,
                PChar Parameters, PChar Directory, int ShowCmd)
            {
                try
                {
                    var startInfo = new global::System.Diagnostics.ProcessStartInfo
	                {
                        FileName = FileName.IsNull() ? string.Empty : FileName.ToString(),
                        UseShellExecute = true,
                        Verb = string.IsNullOrWhiteSpace(Operation) ? "open" : Operation,
                        WindowStyle = ShowCmd == 0
                            ? global::System.Diagnostics.ProcessWindowStyle.Hidden
                            : global::System.Diagnostics.ProcessWindowStyle.Normal
                    };
                    if (!Parameters.IsNull())
                        startInfo.Arguments = Parameters.ToString();
                    if (!Directory.IsNull())
                        startInfo.WorkingDirectory = Directory.ToString();
                    using var process = global::System.Diagnostics.Process.Start(startInfo);
                    return process == null ? 31 : 33;
                }
                catch (global::System.ComponentModel.Win32Exception ex)
                {
                    // ShellExecute returns values > 32 on success.
                    return ex.NativeErrorCode is > 0 and <= 32 ? ex.NativeErrorCode : 31;
                }
                catch (Exception)
                {
                    return 31;
                }
        }

	
} // class ShellapiInterface


file class ShellapiImplementation
{

} // class ShellapiImplementation

}  // namespace Shellapi

}  // namespace Winapi

