{
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
}

unit d7_threadvar;

interface

function RunThreadVarChecks: Boolean;

implementation

uses
  Classes;

threadvar
  ThreadMarker: Integer;

type
  TMarkerThread = class(TThread)
  private
    FRequestedValue: Integer;
    FObservedValue: Integer;
  protected
    procedure Execute; override;
  public
    constructor Create(const AValue: Integer);
    property ObservedValue: Integer read FObservedValue;
  end;

constructor TMarkerThread.Create(const AValue: Integer);
begin
  inherited Create(True);
  FreeOnTerminate := False;
  FRequestedValue := AValue;
  FObservedValue := -1;
end;

procedure TMarkerThread.Execute;
begin
  ThreadMarker := FRequestedValue;
  FObservedValue := ThreadMarker;
end;

function RunThreadVarChecks: Boolean;
var
  FirstThread: TMarkerThread;
  SecondThread: TMarkerThread;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  ThreadMarker := 901;
  FirstThread := TMarkerThread.Create(117);
  SecondThread := TMarkerThread.Create(228);
  try
    FirstThread.Resume;
    SecondThread.Resume;
    FirstThread.WaitFor;
    SecondThread.WaitFor;
    CheckResult1 := (ThreadMarker = 901);
    Result := CheckResult1;

    CheckResult2 := (FirstThread.ObservedValue = 117);
    Result := Result and CheckResult2;

    CheckResult3 := (SecondThread.ObservedValue = 228);
    Result := Result and CheckResult3;
  finally
    FirstThread.Free;
    SecondThread.Free;
  end;
end;

end.
