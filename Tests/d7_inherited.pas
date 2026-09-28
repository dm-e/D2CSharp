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

unit d7_inherited;

interface

function RunInheritedChecks: Boolean;

implementation

type
  TBaseRenderer = class
  public
    function Render(const AText: string): string; virtual;
  end;

  TTaggedRenderer = class(TBaseRenderer)
  public
    function Render(const AText: string): string; override;
  end;

function TBaseRenderer.Render(const AText: string): string;
begin
  Result := 'base[' + AText + ']';
end;

function TTaggedRenderer.Render(const AText: string): string;
begin
  Result := inherited Render(AText) + ':tagged';
end;

function RunInheritedChecks: Boolean;
var
  Renderer: TBaseRenderer;
  CheckResult1: Boolean;
begin
  Renderer := TTaggedRenderer.Create;
  try
    CheckResult1 :=
      Renderer.Render('payload') =
      'base[payload]:tagged';
    Result := CheckResult1;
  finally
    Renderer.Free;
  end;
end;

end.
