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

unit objfree;

interface

function TestNilObjectFree: Boolean;
function TestNilObjectFreeDoesNotCallDestructor: Boolean;
function TestObjectFreeCallsDestructor: Boolean;
function TestObjectFreeUsesVirtualDestructor: Boolean;
function TestObjFreeAll: Boolean;

implementation

type
  TFreeTestObject = class(TObject)
  public
    destructor Destroy; override;
  end;

var
  GDestroyCount: Integer;

destructor TFreeTestObject.Destroy;
begin
  Inc(GDestroyCount);
  inherited Destroy;
end;

function TestNilObjectFree: Boolean;
var
  Obj: TObject;
begin
  Result := False;
  Obj := nil;

  try
    Obj.Free;
    Result := True;
  except
    Result := False;
  end;
end;

function TestNilObjectFreeDoesNotCallDestructor: Boolean;
var
  Obj: TFreeTestObject;
begin
  Result := False;
  Obj := nil;
  GDestroyCount := 0;

  try
    Obj.Free;
    Result := GDestroyCount = 0;
  except
    Result := False;
  end;
end;

function TestObjectFreeCallsDestructor: Boolean;
var
  Obj: TFreeTestObject;
begin
  Result := False;
  Obj := nil;
  GDestroyCount := 0;

  try
    Obj := TFreeTestObject.Create;
    Obj.Free;
    Obj := nil;

    Result := GDestroyCount = 1;
  except
    if Obj <> nil then
      Obj.Free;
    Result := False;
  end;
end;

function TestObjectFreeUsesVirtualDestructor: Boolean;
var
  Obj: TObject;
begin
  Result := False;
  Obj := nil;
  GDestroyCount := 0;

  try
    Obj := TFreeTestObject.Create;
    Obj.Free;
    Obj := nil;

    Result := GDestroyCount = 1;
  except
    if Obj <> nil then
      Obj.Free;
    Result := False;
  end;
end;

function TestObjFreeAll: Boolean;
begin
  Result := True;
  Result := result and TestNilObjectFree;
  Result := result and TestNilObjectFreeDoesNotCallDestructor;
  Result := result and TestObjectFreeCallsDestructor;
  Result := result and TestObjectFreeUsesVirtualDestructor;
end;

end.

