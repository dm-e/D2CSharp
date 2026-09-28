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

unit d7_is_operator;

interface

function RunIsOperatorChecks: Boolean;

implementation

type
  TTransportBase = class
  end;

  TLocalTransport = class(TTransportBase)
  end;

  TRemoteTransport = class(TTransportBase)
  end;

function RunIsOperatorChecks: Boolean;
var
  Transport: TTransportBase;
  TransportClass: TClass;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
begin
  Transport := TLocalTransport.Create;
  try
    TransportClass := TTransportBase;
    CheckResult1 := (Transport is TTransportBase);
    Result := CheckResult1;

    CheckResult2 := (Transport is TransportClass);
    Result := Result and CheckResult2;

    CheckResult3 := (Transport is TLocalTransport);
    Result := Result and CheckResult3;

    CheckResult4 := not (Transport is TRemoteTransport);
    Result := Result and CheckResult4;

    CheckResult5 := (Transport.ClassType = TLocalTransport);
    Result := Result and CheckResult5;

    CheckResult6 := not (Transport.ClassType = TTransportBase);
    Result := Result and CheckResult6;
  finally
    Transport.Free;
  end;
end;

end.
