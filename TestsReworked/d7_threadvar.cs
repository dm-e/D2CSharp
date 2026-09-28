//using System.Classes;
using System;
using static D7_threadvar.D7_threadvarImplementation;
using static D7_threadvar.D7_threadvarInterface;
//using static System.Classes.ClassesInterface;
using static System.SystemInterface;


namespace D7_threadvar
{

    /*
      D2CSharp test file

      Original source language: Delphi (Pascal).
      The corresponding C# files are automatically translated from the
      Delphi source files by D2CSharp.
      This notice is retained unchanged in both versions.

      Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
      SPDX-License-Identifier: Apache-2.0

      Licensed under the Apache License, Version 2.0 (the "License");
      you may not use this file except in compliance with the License.
      You may obtain a copy of the License at

          https://www.apache.org/licenses/LICENSE-2.0

      Unless required by applicable law or agreed to in writing, software
      distributed under the License is distributed on an "AS IS" BASIS,
      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
      See the License for the specific language governing permissions and
      limitations under the License.

      Part of the D2CSharp project by t2t-soft. See LICENSE and NOTICE.
    */


    public class D7_threadvarInterface
    {
        //public static bool RunThreadVarChecks()
        //{
        //    bool result = false;
        //    TMarkerThread FirstThread = default;
        //    TMarkerThread SecondThread = default;
        //    bool CheckResult1 = false;
        //    bool CheckResult2 = false;
        //    bool CheckResult3 = false;
        //    ThreadMarker = 901;
        //    FirstThread = new TMarkerThread(117);
        //    SecondThread = new TMarkerThread(228);
        //    try
        //    {
        //        FirstThread.Resume();
        //        SecondThread.Resume();
        //        FirstThread.WaitFor();
        //        SecondThread.WaitFor();
        //        CheckResult1 = (ThreadMarker == 901);
        //        result = CheckResult1;
        //        CheckResult2 = (FirstThread.ObservedValue == 117);
        //        result = result && CheckResult2;
        //        CheckResult3 = (SecondThread.ObservedValue == 228);
        //        result = result && CheckResult3;
        //    }
        //    finally
        //    {
        //        TObject.Free(FirstThread);
        //        TObject.Free(SecondThread);
        //    }
        //    return result;
        //}

    } // class D7_threadvarInterface


    file class D7_threadvarImplementation
    {

        [ThreadStatic]
        public static int ThreadMarker = 0;

        //public class TMarkerThread : TThread
        //{
        //    private int FRequestedValue;
        //    private int FObservedValue;

        //    protected override void Execute()
        //    {
        //        ThreadMarker = FRequestedValue;
        //        FObservedValue = ThreadMarker;
        //    }
        //    public TMarkerThread(int AValue)
        //    : base(true)
        //    {
        //        //# base.Create(Convert.ToInt32(true));
        //        FreeOnTerminate = false;
        //        FRequestedValue = AValue;
        //        FObservedValue = -1;
        //    }
        //    /*property ObservedValue : int read FObservedValue;*/
        //    public int ObservedValue
        //    {
        //        get
        //        {
        //            return FObservedValue;
        //        }
        //    }

        //    public TMarkerThread()
        //    {
        //    }
        //    public TMarkerThread(bool CreateSuspended) : base(CreateSuspended) { }
        //}
    } // class D7_threadvarImplementation

}  // namespace D7_threadvar

