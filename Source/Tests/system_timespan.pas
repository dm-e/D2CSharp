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

unit system_timespan;

interface

function STS_RunAllTests: Boolean;

implementation

uses
  System.SysUtils,
  System.TimeSpan;

// TTimeSpan.ToString is public starting with Delphi 10.1 Berlin.
// For Delphi XE3, use the public implicit string conversion instead.
// Delphi XE3: CompilerVersion = 24.0
// Delphi 10.1 Berlin: CompilerVersion = 31.0
{$IF CompilerVersion >= 31.0}
  {$DEFINE STS_HAS_PUBLIC_TOSTRING}
{$IFEND}

function STS_TimeSpanText(const Value: TTimeSpan): string;
begin
{$IFDEF STS_HAS_PUBLIC_TOSTRING}
  Result := Value.ToString;
{$ELSE}
  Result := Value;
{$ENDIF}
end;

// All test functions are intentionally private to this unit.
// Each test returns False on an exception or a wrong result.
// Use tolerances only for floating-point results.

function STS_Close(const A, B, Tolerance: Double): Boolean;
begin
  Result := Abs(A - B) <= Tolerance;
end;

function STS_TestTickConstants: Boolean;
begin
  try
    Result := TTimeSpan.TicksPerMillisecond = 10000;
    Result := Result and (TTimeSpan.TicksPerSecond = 10000000);
    Result := Result and (TTimeSpan.TicksPerMinute = 600000000);
    Result := Result and (TTimeSpan.TicksPerHour = Int64(36000000000));
    Result := Result and (TTimeSpan.TicksPerDay = Int64(864000000000));
  except
    Result := False;
  end;
end;

function STS_TestZero: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Zero;
    Result := TS.Ticks = 0;
    Result := Result and (TS.Days = 0);
    Result := Result and (TS.Hours = 0);
    Result := Result and (TS.Minutes = 0);
    Result := Result and (TS.Seconds = 0);
    Result := Result and (TS.Milliseconds = 0);
  except
    Result := False;
  end;
end;

function STS_TestMinMax: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.MinValue;
    B := TTimeSpan.MaxValue;
    Result := A.Ticks = Low(Int64);
    Result := Result and (B.Ticks = High(Int64));
    Result := Result and (A < TTimeSpan.Zero);
    Result := Result and (B > TTimeSpan.Zero);
  except
    Result := False;
  end;
end;

function STS_TestCreateTicks: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(Int64(1234567890123));
    Result := TS.Ticks = Int64(1234567890123);
  except
    Result := False;
  end;
end;

function STS_TestCreateNegativeTicks: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(Int64(-987654321));
    Result := TS.Ticks = Int64(-987654321);
  except
    Result := False;
  end;
end;

function STS_TestCreateHMS: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(2, 3, 4);
    Result := TS.Ticks = Int64(7384) * TTimeSpan.TicksPerSecond;
    Result := Result and (TS.Hours = 2);
    Result := Result and (TS.Minutes = 3);
    Result := Result and (TS.Seconds = 4);
  except
    Result := False;
  end;
end;

function STS_TestCreateDHMS: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(2, 3, 4, 5);
    Result := TS.Ticks = Int64(183845) * TTimeSpan.TicksPerSecond;
    Result := Result and (TS.Days = 2);
    Result := Result and (TS.Hours = 3);
    Result := Result and (TS.Minutes = 4);
    Result := Result and (TS.Seconds = 5);
  except
    Result := False;
  end;
end;

function STS_TestCreateDHMSM: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(1, 2, 3, 4, 567);
    Result := TS.Ticks =
      Int64(93784) * TTimeSpan.TicksPerSecond +
      Int64(567) * TTimeSpan.TicksPerMillisecond;
    Result := Result and (TS.Milliseconds = 567);
  except
    Result := False;
  end;
end;

function STS_TestCreateNegativeHMS: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(-2, -3, -4);
    Result := TS.Ticks = -Int64(7384) * TTimeSpan.TicksPerSecond;
    Result := Result and (TS.Hours = -2);
    Result := Result and (TS.Minutes = -3);
    Result := Result and (TS.Seconds = -4);
  except
    Result := False;
  end;
end;

function STS_TestFromTicks: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromTicks(Int64(567890123));
    Result := TS.Ticks = Int64(567890123);
    TS := TTimeSpan.FromTicks(-1);
    Result := Result and (TS.Ticks = -1);
  except
    Result := False;
  end;
end;

function STS_TestFromMilliseconds: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromMilliseconds(125.0);
    Result := TS.Ticks = 125 * TTimeSpan.TicksPerMillisecond;
    TS := TTimeSpan.FromMilliseconds(-250.0);
    Result := Result and (TS.Ticks = -250 * TTimeSpan.TicksPerMillisecond);
  except
    Result := False;
  end;
end;

function STS_TestFromSeconds: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromSeconds(123.0);
    Result := TS.Ticks = 123 * TTimeSpan.TicksPerSecond;
    TS := TTimeSpan.FromSeconds(-123.0);
    Result := Result and (TS.Ticks = -123 * TTimeSpan.TicksPerSecond);
  except
    Result := False;
  end;
end;

function STS_TestFromMinutes: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromMinutes(25.0);
    Result := TS.Ticks = 25 * TTimeSpan.TicksPerMinute;
    TS := TTimeSpan.FromMinutes(-25.0);
    Result := Result and (TS.Ticks = -25 * TTimeSpan.TicksPerMinute);
  except
    Result := False;
  end;
end;

function STS_TestFromHours: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromHours(26.0);
    Result := TS.Ticks = 26 * TTimeSpan.TicksPerHour;
    TS := TTimeSpan.FromHours(-26.0);
    Result := Result and (TS.Ticks = -26 * TTimeSpan.TicksPerHour);
  except
    Result := False;
  end;
end;

function STS_TestFromDays: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromDays(3.0);
    Result := TS.Ticks = 3 * TTimeSpan.TicksPerDay;
    TS := TTimeSpan.FromDays(-3.0);
    Result := Result and (TS.Ticks = -3 * TTimeSpan.TicksPerDay);
  except
    Result := False;
  end;
end;

function STS_TestFractionalDays: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromDays(1.5);
    Result := TS.Ticks = TTimeSpan.TicksPerDay +
      12 * TTimeSpan.TicksPerHour;
    TS := TTimeSpan.FromDays(-0.25);
    Result := Result and (TS.Ticks = -6 * TTimeSpan.TicksPerHour);
  except
    Result := False;
  end;
end;

function STS_TestFractionalHours: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromHours(1.5);
    Result := TS.Ticks = 90 * TTimeSpan.TicksPerMinute;
    TS := TTimeSpan.FromHours(-2.25);
    Result := Result and (TS.Ticks = -135 * TTimeSpan.TicksPerMinute);
  except
    Result := False;
  end;
end;

function STS_TestFractionalMinutes: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromMinutes(1.5);
    Result := TS.Ticks = 90 * TTimeSpan.TicksPerSecond;
    TS := TTimeSpan.FromMinutes(-0.5);
    Result := Result and (TS.Ticks = -30 * TTimeSpan.TicksPerSecond);
  except
    Result := False;
  end;
end;

function STS_TestFractionalSeconds: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromSeconds(1.125);
    Result := TS.Ticks = TTimeSpan.TicksPerSecond +
      125 * TTimeSpan.TicksPerMillisecond;
    TS := TTimeSpan.FromSeconds(-2.25);
    Result := Result and (TS.Ticks =
      -2 * TTimeSpan.TicksPerSecond -
      250 * TTimeSpan.TicksPerMillisecond);
  except
    Result := False;
  end;
end;

function STS_TestDaysComponent: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromHours(49);
    Result := TS.Days = 2;
    Result := Result and (TS.Hours = 1);
    TS := TTimeSpan.FromHours(23);
    Result := Result and (TS.Days = 0);
  except
    Result := False;
  end;
end;

function STS_TestHoursComponent: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(3, 22, 0, 0);
    Result := TS.Hours = 22;
    TS := TTimeSpan.FromHours(25);
    Result := Result and (TS.Hours = 1);
  except
    Result := False;
  end;
end;

function STS_TestMinutesComponent: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(1, 5, 59, 0);
    Result := TS.Minutes = 59;
    TS := TTimeSpan.FromMinutes(61);
    Result := Result and (TS.Minutes = 1);
  except
    Result := False;
  end;
end;

function STS_TestSecondsComponent: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(1, 2, 3, 59);
    Result := TS.Seconds = 59;
    TS := TTimeSpan.FromSeconds(125);
    Result := Result and (TS.Seconds = 5);
  except
    Result := False;
  end;
end;

function STS_TestMillisecondsComponent: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(0, 0, 0, 1, 999);
    Result := TS.Milliseconds = 999;
    TS := TTimeSpan.FromMilliseconds(1001);
    Result := Result and (TS.Milliseconds = 1);
  except
    Result := False;
  end;
end;

function STS_TestNegativeComponents: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(-1, -2, -3, -4, -500);
    Result := TS.Days = -1;
    Result := Result and (TS.Hours = -2);
    Result := Result and (TS.Minutes = -3);
    Result := Result and (TS.Seconds = -4);
    Result := Result and (TS.Milliseconds = -500);
  except
    Result := False;
  end;
end;

function STS_TestTickPrecision: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromTicks(1);
    Result := TS.Ticks = 1;
    Result := Result and (TS.Milliseconds = 0);
    TS := TTimeSpan.FromTicks(10001);
    Result := Result and (TS.Ticks = 10001);
    Result := Result and (TS.Milliseconds = 1);
  except
    Result := False;
  end;
end;

function STS_TestTotalDays: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromHours(36);
    Result := STS_Close(TS.TotalDays, 1.5, 1E-10);
    TS := TTimeSpan.FromHours(6);
    Result := Result and STS_Close(TS.TotalDays, 0.25, 1E-10);
  except
    Result := False;
  end;
end;

function STS_TestTotalHours: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(2, 3, 30, 0);
    Result := STS_Close(TS.TotalHours, 51.5, 1E-9);
  except
    Result := False;
  end;
end;

function STS_TestTotalMinutes: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(0, 2, 3, 30);
    Result := STS_Close(TS.TotalMinutes, 123.5, 1E-8);
  except
    Result := False;
  end;
end;

function STS_TestTotalSeconds: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(0, 0, 2, 3, 250);
    Result := STS_Close(TS.TotalSeconds, 123.25, 1E-8);
  except
    Result := False;
  end;
end;

function STS_TestTotalMilliseconds: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Create(0, 0, 0, 2, 250);
    Result := STS_Close(TS.TotalMilliseconds, 2250.0, 1E-6);
  except
    Result := False;
  end;
end;

function STS_TestNegativeTotals: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.FromMinutes(-90);
    Result := STS_Close(TS.TotalDays, -0.0625, 1E-10);
    Result := Result and STS_Close(TS.TotalHours, -1.5, 1E-10);
    Result := Result and STS_Close(TS.TotalMinutes, -90, 1E-9);
    Result := Result and STS_Close(TS.TotalSeconds, -5400, 1E-8);
    Result := Result and STS_Close(TS.TotalMilliseconds, -5400000, 1E-6);
  except
    Result := False;
  end;
end;

function STS_TestAddMethod: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.Create(1, 2, 0);
    B := TTimeSpan.Create(0, 3, 4);
    C := A.Add(B);
    Result := C.Ticks = A.Ticks + B.Ticks;
    Result := Result and (C.Hours = 1);
    Result := Result and (C.Minutes = 5);
    Result := Result and (C.Seconds = 4);
  except
    Result := False;
  end;
end;

function STS_TestAddNegative: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromMinutes(10);
    B := TTimeSpan.FromMinutes(-25);
    C := A.Add(B);
    Result := C.Ticks = -15 * TTimeSpan.TicksPerMinute;
    Result := Result and (A.Ticks = 10 * TTimeSpan.TicksPerMinute);
    Result := Result and (B.Ticks = -25 * TTimeSpan.TicksPerMinute);
  except
    Result := False;
  end;
end;

function STS_TestSubtractMethod: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromMinutes(90);
    B := TTimeSpan.FromMinutes(25);
    C := A.Subtract(B);
    Result := C.Ticks = 65 * TTimeSpan.TicksPerMinute;
  except
    Result := False;
  end;
end;

function STS_TestSubtractNegative: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromSeconds(-10);
    B := TTimeSpan.FromSeconds(5);
    C := A.Subtract(B);
    Result := C.Ticks = -15 * TTimeSpan.TicksPerSecond;
  except
    Result := False;
  end;
end;

function STS_TestDuration: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromMinutes(-120);
    B := A.Duration;
    Result := B.Ticks = 120 * TTimeSpan.TicksPerMinute;
    A := TTimeSpan.FromSeconds(5);
    B := A.Duration;
    Result := Result and (B.Ticks = A.Ticks);
  except
    Result := False;
  end;
end;

function STS_TestNegate: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromMinutes(90);
    B := A.Negate;
    Result := B.Ticks = -A.Ticks;
    B := B.Negate;
    Result := Result and (B.Ticks = A.Ticks);
    B := TTimeSpan.Zero;
    B := B.Negate;
    Result := Result and (B.Ticks = 0);
  except
    Result := False;
  end;
end;

function STS_TestOperatorAdd: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(2);
    B := TTimeSpan.FromMinutes(30);
    C := A + B;
    Result := C.Ticks = 150 * TTimeSpan.TicksPerMinute;
  except
    Result := False;
  end;
end;

function STS_TestOperatorSubtract: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(1);
    B := TTimeSpan.FromMinutes(90);
    C := A - B;
    Result := C.Ticks = -30 * TTimeSpan.TicksPerMinute;
  except
    Result := False;
  end;
end;

function STS_TestOperatorNegative: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromSeconds(17);
    B := -A;
    Result := B.Ticks = -17 * TTimeSpan.TicksPerSecond;
    B := -B;
    Result := Result and (B.Ticks = A.Ticks);
  except
    Result := False;
  end;
end;

function STS_TestOperatorPositive: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromSeconds(-17);
    B := +A;
    Result := B.Ticks = A.Ticks;
  except
    Result := False;
  end;
end;

function STS_TestOperatorEqual: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromMinutes(60);
    B := TTimeSpan.FromHours(1);
    C := TTimeSpan.FromMinutes(61);
    Result := A = B;
    Result := Result and (B = A);
    Result := Result and not (A = C);
  except
    Result := False;
  end;
end;

function STS_TestOperatorNotEqual: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromSeconds(1);
    B := TTimeSpan.FromSeconds(2);
    C := TTimeSpan.FromTicks(A.Ticks);
    Result := A <> B;
    Result := Result and not (A <> C);
  except
    Result := False;
  end;
end;

function STS_TestOperatorLessThan: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(1);
    B := TTimeSpan.FromHours(2);
    Result := A < B;
    Result := Result and not (B < A);
    Result := Result and not (A < A);
  except
    Result := False;
  end;
end;

function STS_TestOperatorLessOrEqual: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(1);
    B := TTimeSpan.FromHours(2);
    Result := A <= B;
    Result := Result and (A <= A);
    Result := Result and not (B <= A);
  except
    Result := False;
  end;
end;

function STS_TestOperatorGreaterThan: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(2);
    B := TTimeSpan.FromHours(1);
    Result := A > B;
    Result := Result and not (B > A);
    Result := Result and not (A > A);
  except
    Result := False;
  end;
end;

function STS_TestOperatorGreaterOrEqual: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(2);
    B := TTimeSpan.FromHours(1);
    Result := A >= B;
    Result := Result and (A >= A);
    Result := Result and not (B >= A);
  except
    Result := False;
  end;
end;

function STS_TestOperatorNegativeCompare: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromTicks(-2);
    B := TTimeSpan.FromTicks(-1);
    C := TTimeSpan.Zero;
    Result := A < B;
    Result := Result and (B < C);
    Result := Result and (C > A);
    Result := Result and (A <> C);
  except
    Result := False;
  end;
end;

function STS_TestAddDoesNotMutate: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(2);
    B := TTimeSpan.FromMinutes(30);
    C := A.Add(B);
    Result := A.Ticks = 2 * TTimeSpan.TicksPerHour;
    Result := Result and (B.Ticks = 30 * TTimeSpan.TicksPerMinute);
    Result := Result and (C.Ticks = 150 * TTimeSpan.TicksPerMinute);
  except
    Result := False;
  end;
end;

function STS_TestToStringZero: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Zero;
    S := STS_TimeSpanText(TS);
    Result := S = '00:00:00';
  except
    Result := False;
  end;
end;

function STS_TestToStringHMS: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Create(1, 2, 3);
    S := STS_TimeSpanText(TS);
    Result := S = '01:02:03';
  except
    Result := False;
  end;
end;

function STS_TestToStringDays: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Create(2, 3, 4, 5);
    S := STS_TimeSpanText(TS);
    Result := S = '2.03:04:05';
  except
    Result := False;
  end;
end;

function STS_TestToStringNegative: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Create(-2, -3, -4);
    S := STS_TimeSpanText(TS);
    Result := TS.Ticks = -Int64(7384) * TTimeSpan.TicksPerSecond;
    // XE3: the implicit string conversion omits the minus sign.
    // Check the observed RTL behavior, not the .NET formatting rule.
{$IF CompilerVersion = 24.0}
    Result := Result and (S = '02:03:04');
{$ELSE}
    Result := Result and (S = '-02:03:04');
{$IFEND}
  except
    Result := False;
  end;
end;

function STS_TestParseHMS: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Parse('01:02:03');
    Result := TS.Ticks = 3723 * TTimeSpan.TicksPerSecond;
  except
    Result := False;
  end;
end;

function STS_TestParseDays: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Parse('2.03:04:05');
    Result := TS.Ticks = 183845 * TTimeSpan.TicksPerSecond;
  except
    Result := False;
  end;
end;

function STS_TestParseNegative: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Parse('-01:02:03');
    Result := TS.Ticks = -3723 * TTimeSpan.TicksPerSecond;
  except
    Result := False;
  end;
end;

function STS_TestParseFraction: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Parse('00:00:01.250');
    Result := TS.Ticks = TTimeSpan.TicksPerSecond +
      250 * TTimeSpan.TicksPerMillisecond;
  except
    Result := False;
  end;
end;

function STS_TestTryParseValid: Boolean;
var
  TS: TTimeSpan;
begin
  try
    Result := TTimeSpan.TryParse('01:30:00', TS);
    Result := Result and (TS.Ticks = 90 * TTimeSpan.TicksPerMinute);
    Result := Result and TTimeSpan.TryParse('2.00:00:00', TS);
    Result := Result and (TS.Ticks = 2 * TTimeSpan.TicksPerDay);
  except
    Result := False;
  end;
end;

function STS_TestTryParseInvalid: Boolean;
var
  TS: TTimeSpan;
begin
  try
    Result := not TTimeSpan.TryParse('invalid time span', TS);
    Result := Result and not TTimeSpan.TryParse('', TS);
  except
    Result := False;
  end;
end;

function STS_TestParseInvalidRaises: Boolean;
var
  TS: TTimeSpan;
begin
  Result := False;
  try
    TS := TTimeSpan.Parse('invalid time span');
  except
    on E: Exception do
      Result := True;
  end;
end;

function STS_TestToStringRoundTrip: Boolean;
var
  A, B: TTimeSpan;
  S: string;
begin
  try
    A := TTimeSpan.Create(3, 4, 5, 6, 250);
    S := STS_TimeSpanText(A);
    B := TTimeSpan.Parse(S);
    Result := A.Ticks = B.Ticks;
    A := TTimeSpan.Create(-2, -3, -4);
    S := STS_TimeSpanText(A);
    B := TTimeSpan.Parse(S);
    // XE3: the implicit conversion of a negative TTimeSpan
    // omits its sign. Parse therefore returns a positive value.
{$IF CompilerVersion = 24.0}
    Result := Result and (A.Ticks < 0);
    Result := Result and (S = '02:03:04');
    Result := Result and (B.Ticks > 0);
    Result := Result and (B.Ticks = -A.Ticks);
{$ELSE}
    Result := Result and (A.Ticks = B.Ticks);
{$IFEND}
  except
    Result := False;
  end;
end;

function STS_TestStringImplicit: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Create(1, 2, 3);
    S := TS;
    Result := S = '01:02:03';
  except
    Result := False;
  end;
end;

function STS_TestStringExplicit: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Create(1, 2, 3);
    S := string(TS);
    Result := S = '01:02:03';
  except
    Result := False;
  end;
end;

function STS_TestDateSubtractDays: Boolean;
var
  A, B: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 10);
    B := EncodeDate(2020, 1, 7);
    TS := TTimeSpan.Subtract(A, B);
    Result := TS.Ticks = 3 * TTimeSpan.TicksPerDay;
  except
    Result := False;
  end;
end;

function STS_TestDateSubtractHours: Boolean;
var
  A, B: TDateTime;
  TS: TTimeSpan;
begin
  try
    B := EncodeDate(2020, 1, 10) + EncodeTime(10, 0, 0, 0);
    A := EncodeDate(2020, 1, 10) + EncodeTime(16, 0, 0, 0);
    TS := TTimeSpan.Subtract(A, B);
    Result := TS.Ticks = 6 * TTimeSpan.TicksPerHour;
  except
    Result := False;
  end;
end;

function STS_TestDateSubtractNegative: Boolean;
var
  A, B: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 7);
    B := EncodeDate(2020, 1, 10);
    TS := TTimeSpan.Subtract(A, B);
    Result := TS.Ticks = -3 * TTimeSpan.TicksPerDay;
  except
    Result := False;
  end;
end;

function STS_TestDateAddSpanRight: Boolean;
var
  A, B, Expected: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 10) + EncodeTime(12, 0, 0, 0);
    TS := TTimeSpan.FromHours(6);
    B := A + TS;
    Expected := EncodeDate(2020, 1, 10) + EncodeTime(18, 0, 0, 0);
    Result := STS_Close(B, Expected, 1E-9);
  except
    Result := False;
  end;
end;

function STS_TestDateAddSpanLeft: Boolean;
var
  A, B, Expected: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 10) + EncodeTime(12, 0, 0, 0);
    TS := TTimeSpan.FromHours(6);
    B := TS + A;
    Expected := EncodeDate(2020, 1, 10) + EncodeTime(18, 0, 0, 0);
    Result := STS_Close(B, Expected, 1E-9);
  except
    Result := False;
  end;
end;

function STS_TestDateSubtractSpan: Boolean;
var
  A, B, Expected: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 10) + EncodeTime(12, 0, 0, 0);
    TS := TTimeSpan.FromHours(6);
    B := A - TS;
    Expected := EncodeDate(2020, 1, 10) + EncodeTime(6, 0, 0, 0);
    Result := STS_Close(B, Expected, 1E-9);
  except
    Result := False;
  end;
end;

function STS_TestDateCrossMidnight: Boolean;
var
  A, B, Expected: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 10) + EncodeTime(23, 0, 0, 0);
    TS := TTimeSpan.FromHours(2);
    B := A + TS;
    Expected := EncodeDate(2020, 1, 11) + EncodeTime(1, 0, 0, 0);
    Result := STS_Close(B, Expected, 1E-9);
  except
    Result := False;
  end;
end;

function STS_TestToStringFraction: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.Create(0, 0, 0, 0, 250);
    S := STS_TimeSpanText(TS);
    Result := S = '00:00:00.2500000';
  except
    Result := False;
  end;
end;

function STS_TestToStringOneTick: Boolean;
var
  TS: TTimeSpan;
  S: string;
begin
  try
    TS := TTimeSpan.FromTicks(1);
    S := STS_TimeSpanText(TS);
    Result := S = '00:00:00.0000001';
  except
    Result := False;
  end;
end;

function STS_TestParseZero: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Parse('00:00:00');
    Result := TS.Ticks = 0;
  except
    Result := False;
  end;
end;

function STS_TestParseOneTick: Boolean;
var
  TS: TTimeSpan;
begin
  try
    TS := TTimeSpan.Parse('00:00:00.0000001');
    Result := TS.Ticks = 1;
  except
    Result := False;
  end;
end;

function STS_TestTryParseOneTick: Boolean;
var
  TS: TTimeSpan;
begin
  try
    Result := TTimeSpan.TryParse('00:00:00.0000001', TS);
    Result := Result and (TS.Ticks = 1);
  except
    Result := False;
  end;
end;

function STS_TestFromTicksBoundaries: Boolean;
var
  A, B: TTimeSpan;
begin
  try
    A := TTimeSpan.FromTicks(Low(Int64));
    B := TTimeSpan.FromTicks(High(Int64));
    Result := A.Ticks = Low(Int64);
    Result := Result and (B.Ticks = High(Int64));
  except
    Result := False;
  end;
end;

function STS_TestOperatorDayCarry: Boolean;
var
  A, B, C: TTimeSpan;
begin
  try
    A := TTimeSpan.FromHours(23);
    B := TTimeSpan.FromHours(2);
    C := A + B;
    Result := C.Days = 1;
    Result := Result and (C.Hours = 1);
    Result := Result and (C.Ticks = 25 * TTimeSpan.TicksPerHour);
  except
    Result := False;
  end;
end;

function STS_TestDateArithmeticRoundTrip: Boolean;
var
  A, B: TDateTime;
  TS: TTimeSpan;
begin
  try
    A := EncodeDate(2020, 1, 10) + EncodeTime(6, 0, 0, 0);
    TS := TTimeSpan.FromHours(12);
    B := A + TS;
    B := B - TS;
    Result := STS_Close(A, B, 1E-9);
  except
    Result := False;
  end;
end;

// Force evaluation of all test functions, even after a failure.
// The translated C# runner should preserve eager evaluation as well.
{$B+}
function STS_RunAllTests: Boolean;
begin
  Result := True;
  Result := Result and STS_TestTickConstants;
  Result := Result and STS_TestZero;
  Result := Result and STS_TestMinMax;
  Result := Result and STS_TestCreateTicks;
  Result := Result and STS_TestCreateNegativeTicks;
  Result := Result and STS_TestCreateHMS;
  Result := Result and STS_TestCreateDHMS;
  Result := Result and STS_TestCreateDHMSM;
  Result := Result and STS_TestCreateNegativeHMS;
  Result := Result and STS_TestFromTicks;
  Result := Result and STS_TestFromMilliseconds;
  Result := Result and STS_TestFromSeconds;
  Result := Result and STS_TestFromMinutes;
  Result := Result and STS_TestFromHours;
  Result := Result and STS_TestFromDays;
  Result := Result and STS_TestFractionalDays;
  Result := Result and STS_TestFractionalHours;
  Result := Result and STS_TestFractionalMinutes;
  Result := Result and STS_TestFractionalSeconds;
  Result := Result and STS_TestDaysComponent;
  Result := Result and STS_TestHoursComponent;
  Result := Result and STS_TestMinutesComponent;
  Result := Result and STS_TestSecondsComponent;
  Result := Result and STS_TestMillisecondsComponent;
  Result := Result and STS_TestNegativeComponents;
  Result := Result and STS_TestTickPrecision;
  Result := Result and STS_TestTotalDays;
  Result := Result and STS_TestTotalHours;
  Result := Result and STS_TestTotalMinutes;
  Result := Result and STS_TestTotalSeconds;
  Result := Result and STS_TestTotalMilliseconds;
  Result := Result and STS_TestNegativeTotals;
  Result := Result and STS_TestAddMethod;
  Result := Result and STS_TestAddNegative;
  Result := Result and STS_TestSubtractMethod;
  Result := Result and STS_TestSubtractNegative;
  Result := Result and STS_TestDuration;
  Result := Result and STS_TestNegate;
  Result := Result and STS_TestOperatorAdd;
  Result := Result and STS_TestOperatorSubtract;
  Result := Result and STS_TestOperatorNegative;
  Result := Result and STS_TestOperatorPositive;
  Result := Result and STS_TestOperatorEqual;
  Result := Result and STS_TestOperatorNotEqual;
  Result := Result and STS_TestOperatorLessThan;
  Result := Result and STS_TestOperatorLessOrEqual;
  Result := Result and STS_TestOperatorGreaterThan;
  Result := Result and STS_TestOperatorGreaterOrEqual;
  Result := Result and STS_TestOperatorNegativeCompare;
  Result := Result and STS_TestAddDoesNotMutate;
  Result := Result and STS_TestToStringZero;
  Result := Result and STS_TestToStringHMS;
  Result := Result and STS_TestToStringDays;
  Result := Result and STS_TestToStringNegative;
  Result := Result and STS_TestParseHMS;
  Result := Result and STS_TestParseDays;
  Result := Result and STS_TestParseNegative;
  Result := Result and STS_TestParseFraction;
  Result := Result and STS_TestTryParseValid;
  Result := Result and STS_TestTryParseInvalid;
  Result := Result and STS_TestParseInvalidRaises;
  Result := Result and STS_TestToStringRoundTrip;
  Result := Result and STS_TestStringImplicit;
  Result := Result and STS_TestStringExplicit;
  Result := Result and STS_TestDateSubtractDays;
  Result := Result and STS_TestDateSubtractHours;
  Result := Result and STS_TestDateSubtractNegative;
  Result := Result and STS_TestDateAddSpanRight;
  Result := Result and STS_TestDateAddSpanLeft;
  Result := Result and STS_TestDateSubtractSpan;
  Result := Result and STS_TestDateCrossMidnight;
  Result := Result and STS_TestToStringFraction;
  Result := Result and STS_TestToStringOneTick;
  Result := Result and STS_TestParseZero;
  Result := Result and STS_TestParseOneTick;
  Result := Result and STS_TestTryParseOneTick;
  Result := Result and STS_TestFromTicksBoundaries;
  Result := Result and STS_TestOperatorDayCarry;
  Result := Result and STS_TestDateArithmeticRoundTrip;
end;
{$B-}

end.
