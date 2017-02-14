#region License
// 
// Copyright (c) 2007-2009, Sean Chambers <schambers80@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace FluentMigrator.Console
{
    class Program
    {
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        static void Main(string[] args)
        {
            try
            {
                if (args.Contains("--silent"))
                {
                    //Hide the console window
                    IntPtr hWnd = GetConsoleWindow();
                    if (hWnd != IntPtr.Zero)
                    {
                        //SW_SHOW = 5, SW_HIDE = 0
                        ShowWindow(hWnd, 0);
                    }
                }

                new MigratorConsole(args);
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}