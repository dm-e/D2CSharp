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

unit d7_data_types;

interface

type
  TBuildAgent = record
    Identifier: string[24];
    HostName: string[32];
    WorkerCount: Byte;
  end;

function RunDataTypeChecks: Boolean;

implementation

type
  TWorkDays = set of 1..7;
  TTransport = (trLocal, trNetwork, trCloud, trOffline);

const
  DefaultAgent = 'runner-a';
  DefaultWorkers = 6;
  DefaultLoad: Single = 72.5;
  DefaultEnabled = True;

var
  ByteValue: Byte;
  ShortValue: ShortInt;
  WordValue: Word;
  SmallValue: SmallInt;
  LongWordValue: LongWord;
  CardinalValue: Cardinal;
  LongValue: LongInt;
  IntegerValue: Integer;
  Int64Value: Int64;
  UInt64Value: UInt64;
  NativeIntegerValue: NativeInt;
  NativeUnsignedValue: NativeUInt;
  SingleValue: Single;
  CurrencyValue: Currency;
  DoubleValue: Double;
  ExtendedValue: Extended;
  RealValue: Real;
  Real48Value: Real48;
  CharValue: Char;
  WideCharValue: WideChar;
  AnsiCharValue: AnsiChar;
  ShortText: ShortString;
  UnicodeText: string;
  AnsiText: AnsiString;
  WideText: WideString;
  ByteBooleanValue: ByteBool;
  LongBooleanValue: LongBool;
  WordBooleanValue: WordBool;
  PointerValue: Pointer;
  TransportNames: array[0..3] of string;

function CheckNumericAssignments: Boolean;
var
  ByteValueOk: Boolean;
  ShortValueOk: Boolean;
  WordValueOk: Boolean;
  SmallValueOk: Boolean;
  LongWordValueOk: Boolean;
  CardinalValueOk: Boolean;
  LongValueOk: Boolean;
  IntegerValueOk: Boolean;
  Int64ValueOk: Boolean;
  UInt64ValueOk: Boolean;
  NativeIntegerValueOk: Boolean;
  NativeUnsignedValueOk: Boolean;
  SingleValueOk: Boolean;
  CurrencyValueOk: Boolean;
  DoubleValueOk: Boolean;
  ExtendedValueOk: Boolean;
  RealValueOk: Boolean;
  Real48ValueOk: Boolean;
begin
  ByteValue := 240;
  ShortValue := -100;
  WordValue := 60000;
  SmallValue := -30000;
  LongWordValue := 3000000000;
  CardinalValue := 4000000000;
  LongValue := -2000000000;
  IntegerValue := ShortValue;
  Int64Value := 7000000000;
  UInt64Value := 12000000000;
  NativeIntegerValue := 1024;
  NativeUnsignedValue := 2048;

  SingleValue := DefaultLoad;
  CurrencyValue := 81.1250;
  DoubleValue := 1.25E100;
  ExtendedValue := 3.141592653589793238;
  RealValue := 12.75;
  Real48Value := 6.5;

  ByteValueOk := ByteValue = 240;
  ShortValueOk := ShortValue = -100;
  WordValueOk := WordValue = 60000;
  SmallValueOk := SmallValue = -30000;
  LongWordValueOk := LongWordValue = 3000000000;
  CardinalValueOk := CardinalValue = 4000000000;
  LongValueOk := LongValue = -2000000000;
  IntegerValueOk := IntegerValue = -100;
  Int64ValueOk := Int64Value = 7000000000;
  UInt64ValueOk := UInt64Value = 12000000000;
  NativeIntegerValueOk := NativeIntegerValue = 1024;
  NativeUnsignedValueOk := NativeUnsignedValue = 2048;
  SingleValueOk := SingleValue = DefaultLoad;
  CurrencyValueOk := CurrencyValue = 81.1250;
  DoubleValueOk := DoubleValue > 1E99;
  ExtendedValueOk := ExtendedValue > 3.14;
  RealValueOk := RealValue = 12.75;
  Real48ValueOk := Real48Value = 6.5;

  Result :=
    ByteValueOk and
    ShortValueOk and
    WordValueOk and
    SmallValueOk and
    LongWordValueOk and
    CardinalValueOk and
    LongValueOk and
    IntegerValueOk and
    Int64ValueOk and
    UInt64ValueOk and
    NativeIntegerValueOk and
    NativeUnsignedValueOk and
    SingleValueOk and
    CurrencyValueOk and
    DoubleValueOk and
    ExtendedValueOk and
    RealValueOk and
    Real48ValueOk;
end;

function CheckTextAndBooleanTypes: Boolean;
var
  CharValueOk: Boolean;
  WideCharValueOk: Boolean;
  AnsiCharValueOk: Boolean;
  ShortTextOk: Boolean;
  UnicodeTextOk: Boolean;
  AnsiTextOk: Boolean;
  WideTextOk: Boolean;
  ByteBooleanValueOk: Boolean;
  LongBooleanValueOk: Boolean;
  WordBooleanValueOk: Boolean;
  PointerValueOk: Boolean;
begin
  CharValue := 'R';
  WideCharValue := #$03A9;
  AnsiCharValue := 'A';
  ShortText := 'short';
  UnicodeText := 'unicode';
  AnsiText := 'ansi';
  WideText := 'wide';
  ByteBooleanValue := True;
  LongBooleanValue := True;
  WordBooleanValue := False;
  PointerValue := nil;

  CharValueOk := CharValue = 'R';
  WideCharValueOk := WideCharValue = #$03A9;
  AnsiCharValueOk := AnsiCharValue = 'A';
  ShortTextOk := ShortText = 'short';
  UnicodeTextOk := UnicodeText = 'unicode';
  AnsiTextOk := AnsiText = 'ansi';
  WideTextOk := WideText = 'wide';
  ByteBooleanValueOk := ByteBooleanValue = True;
  LongBooleanValueOk := LongBooleanValue = True;
  WordBooleanValueOk := WordBooleanValue = False;
  PointerValueOk := PointerValue = nil;

  Result :=
    CharValueOk and
    WideCharValueOk and
    AnsiCharValueOk and
    ShortTextOk and
    UnicodeTextOk and
    AnsiTextOk and
    WideTextOk and
    ByteBooleanValueOk and
    LongBooleanValueOk and
    WordBooleanValueOk and
    PointerValueOk;
end;

function CheckSubranges: Boolean;
type
  TPriority = 1..5;
  TUpperLetter = 'A'..'Z';
  TDigitCharacter = '0'..'9';
var
  Priority: TPriority;
  Letter: TUpperLetter;
  Digit: TDigitCharacter;
  PriorityOk: Boolean;
  LetterOk: Boolean;
  DigitOk: Boolean;
begin
  Priority := 4;
  Letter := 'M';
  Digit := '8';

  PriorityOk := Priority = 4;
  LetterOk := Letter = 'M';
  DigitOk := Digit = '8';

  Result :=
    PriorityOk and
    LetterOk and
    DigitOk;
end;

function CheckRecordSetEnumAndArray: Boolean;
var
  Agent: TBuildAgent;
  ActiveDays: TWorkDays;
  Transport: TTransport;
  AgentIdentifierOk: Boolean;
  AgentHostNameOk: Boolean;
  AgentWorkerCountOk: Boolean;
  DefaultEnabledOk: Boolean;
  ActiveDay1Ok: Boolean;
  ActiveDay2Ok: Boolean;
  ActiveDay5Ok: Boolean;
  TransportOk: Boolean;
  TransportNameOk: Boolean;
begin
  Agent.Identifier := DefaultAgent;
  Agent.HostName := 'node-17';
  Agent.WorkerCount := DefaultWorkers;

  ActiveDays := [1, 3, 5];
  Transport := trCloud;

  TransportNames[0] := 'local';
  TransportNames[1] := 'network';
  TransportNames[2] := 'cloud';
  TransportNames[3] := 'offline';

  AgentIdentifierOk := Agent.Identifier = 'runner-a';
  AgentHostNameOk := Agent.HostName = 'node-17';
  AgentWorkerCountOk := Agent.WorkerCount = 6;
  DefaultEnabledOk := DefaultEnabled = True;
  ActiveDay1Ok := 1 in ActiveDays;
  ActiveDay2Ok := not (2 in ActiveDays);
  ActiveDay5Ok := 5 in ActiveDays;
  TransportOk := Transport = trCloud;
  TransportNameOk := TransportNames[Ord(Transport)] = 'cloud';

  Result :=
    AgentIdentifierOk and
    AgentHostNameOk and
    AgentWorkerCountOk and
    DefaultEnabledOk and
    ActiveDay1Ok and
    ActiveDay2Ok and
    ActiveDay5Ok and
    TransportOk and
    TransportNameOk;
end;

function RunDataTypeChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  CheckResult1 := CheckNumericAssignments;
  CheckResult2 := CheckTextAndBooleanTypes;
  CheckResult3 := CheckSubranges;
  CheckResult4 := CheckRecordSetEnumAndArray;

  Result :=
    CheckResult1 and
    CheckResult2 and
    CheckResult3 and
    CheckResult4;
end;

end.
