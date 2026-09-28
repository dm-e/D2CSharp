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

unit d7_tlist;

interface

function RunTListChecks: Boolean;

implementation

uses
  Classes,
  SysUtils;

type
  TQueueItem = class
  private
    FLabelText: string;
    FPriority: Integer;
  public
    constructor Create(const ALabelText: string;
      const APriority: Integer);
    property LabelText: string read FLabelText;
    property Priority: Integer read FPriority;
  end;

constructor TQueueItem.Create(const ALabelText: string;
  const APriority: Integer);
begin
  inherited Create;
  FLabelText := ALabelText;
  FPriority := APriority;
end;

function CompareQueueItems(Item1, Item2: Pointer): Integer;
begin
  Result := TQueueItem(Item1).Priority - TQueueItem(Item2).Priority;
  if Result = 0 then
    Result := CompareStr(TQueueItem(Item1).LabelText,
      TQueueItem(Item2).LabelText);
end;

procedure FreeItems(const AList: TList);
var
  Index: Integer;
begin
  for Index := AList.Count - 1 downto 0 do
    TObject(AList[Index]).Free;
  AList.Clear;
end;

function RunTListChecks: Boolean;
var
  Items: TList;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
begin
  Items := TList.Create;
  try
    Items.Add(TQueueItem.Create('compile', 30));
    Items.Add(TQueueItem.Create('scan', 10));
    Items.Insert(1, TQueueItem.Create('parse', 20));

    CheckResult1 := (Items.Count = 3);
    Result := CheckResult1;

    CheckResult2 := (TQueueItem(Items[1]).LabelText = 'parse');
    Result := Result and CheckResult2;

    CheckResult3 := (Items.IndexOf(Items[2]) = 2);
    Result := Result and CheckResult3;

    Items.Sort(CompareQueueItems);
    CheckResult4 := (TQueueItem(Items[0]).LabelText = 'scan');
    Result := Result and CheckResult4;

    CheckResult5 := (TQueueItem(Items[1]).LabelText = 'parse');
    Result := Result and CheckResult5;

    CheckResult6 := (TQueueItem(Items[2]).LabelText = 'compile');
    Result := Result and CheckResult6;

    Items.Exchange(0, 2);
    CheckResult7 := (TQueueItem(Items[0]).LabelText = 'compile');
    Result := Result and CheckResult7;

    TQueueItem(Items[1]).Free;
    Items.Delete(1);
    Items.Add(nil);
    Items.Pack;
    CheckResult8 := (Items.Count = 2);
    Result := Result and CheckResult8;
  finally
    FreeItems(Items);
    Items.Free;
  end;
end;

end.
