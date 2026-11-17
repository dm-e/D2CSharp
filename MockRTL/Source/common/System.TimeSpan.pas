{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.TimeSpan.
  Public TTimeSpan declarations for conversion and RTL development.
  Methods intentionally return default values; no time calculations are performed.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.TimeSpan;

interface

type
  TTimeSpan = record
  private
    FTicks: Int64;
    class var FMinValue: TTimeSpan;
    class var FMaxValue: TTimeSpan;
    class var FZero: TTimeSpan;
    function GetDays: Integer;
    function GetHours: Integer;
    function GetMinutes: Integer;
    function GetSeconds: Integer;
    function GetMilliseconds: Integer;
    function GetTotalDays: Double;
    function GetTotalHours: Double;
    function GetTotalMinutes: Double;
    function GetTotalSeconds: Double;
    function GetTotalMilliseconds: Double;
  public
    const TicksPerMillisecond = 10000;
    const TicksPerSecond = Int64(10000000);
    const TicksPerMinute = Int64(600000000);
    const TicksPerHour = Int64(36000000000);
    const TicksPerDay = Int64(864000000000);

    constructor Create(ATicks: Int64); overload;
    constructor Create(Hours, Minutes, Seconds: Integer); overload;
    constructor Create(Days, Hours, Minutes, Seconds: Integer); overload;
    constructor Create(Days, Hours, Minutes, Seconds, Milliseconds: Integer); overload;

    function Add(const TS: TTimeSpan): TTimeSpan; overload;
    function Duration: TTimeSpan;
    function Negate: TTimeSpan;
    function Subtract(const TS: TTimeSpan): TTimeSpan; overload;
    function ToString: string;

    class function FromDays(Value: Double): TTimeSpan; static;
    class function FromHours(Value: Double): TTimeSpan; static;
    class function FromMinutes(Value: Double): TTimeSpan; static;
    class function FromSeconds(Value: Double): TTimeSpan; static;
    class function FromMilliseconds(Value: Double): TTimeSpan; static;
    class function FromTicks(Value: Int64): TTimeSpan; static;
    class function Subtract(const D1, D2: TDateTime): TTimeSpan; overload; static;
    class function Parse(const S: string): TTimeSpan; static;
    class function TryParse(const S: string; out Value: TTimeSpan): Boolean; static;

    class operator Add(const Left, Right: TTimeSpan): TTimeSpan;
    class operator Add(const Left: TTimeSpan; Right: TDateTime): TDateTime;
    class operator Add(const Left: TDateTime; Right: TTimeSpan): TDateTime;
    class operator Subtract(const Left, Right: TTimeSpan): TTimeSpan;
    class operator Subtract(const Left: TDateTime; Right: TTimeSpan): TDateTime;
    class operator Equal(const Left, Right: TTimeSpan): Boolean;
    class operator NotEqual(const Left, Right: TTimeSpan): Boolean;
    class operator GreaterThan(const Left, Right: TTimeSpan): Boolean;
    class operator GreaterThanOrEqual(const Left, Right: TTimeSpan): Boolean;
    class operator LessThan(const Left, Right: TTimeSpan): Boolean;
    class operator LessThanOrEqual(const Left, Right: TTimeSpan): Boolean;
    class operator Negative(const Value: TTimeSpan): TTimeSpan;
    class operator Positive(const Value: TTimeSpan): TTimeSpan;
    class operator Implicit(const Value: TTimeSpan): string;
    class operator Explicit(const Value: TTimeSpan): string;

    property Ticks: Int64 read FTicks;
    property Days: Integer read GetDays;
    property Hours: Integer read GetHours;
    property Minutes: Integer read GetMinutes;
    property Seconds: Integer read GetSeconds;
    property Milliseconds: Integer read GetMilliseconds;
    property TotalDays: Double read GetTotalDays;
    property TotalHours: Double read GetTotalHours;
    property TotalMinutes: Double read GetTotalMinutes;
    property TotalSeconds: Double read GetTotalSeconds;
    property TotalMilliseconds: Double read GetTotalMilliseconds;
    class property MinValue: TTimeSpan read FMinValue;
    class property MaxValue: TTimeSpan read FMaxValue;
    class property Zero: TTimeSpan read FZero;
  end;

implementation

constructor TTimeSpan.Create(ATicks: Int64);
begin
  FTicks := 0;
end;

constructor TTimeSpan.Create(Hours, Minutes, Seconds: Integer);
begin
  FTicks := 0;
end;

constructor TTimeSpan.Create(Days, Hours, Minutes, Seconds: Integer);
begin
  FTicks := 0;
end;

constructor TTimeSpan.Create(Days, Hours, Minutes, Seconds, Milliseconds: Integer);
begin
  FTicks := 0;
end;

function TTimeSpan.Add(const TS: TTimeSpan): TTimeSpan;
begin
  Result.FTicks := 0;
end;

function TTimeSpan.Duration: TTimeSpan;
begin
  Result.FTicks := 0;
end;

function TTimeSpan.Negate: TTimeSpan;
begin
  Result.FTicks := 0;
end;

function TTimeSpan.Subtract(const TS: TTimeSpan): TTimeSpan;
begin
  Result.FTicks := 0;
end;

function TTimeSpan.ToString: string;
begin
  Result := '';
end;

class function TTimeSpan.FromDays(Value: Double): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.FromHours(Value: Double): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.FromMinutes(Value: Double): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.FromSeconds(Value: Double): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.FromMilliseconds(Value: Double): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.FromTicks(Value: Int64): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.Subtract(const D1, D2: TDateTime): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.Parse(const S: string): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class function TTimeSpan.TryParse(const S: string; out Value: TTimeSpan): Boolean;
begin
  Value.FTicks := 0;
  Result := False;
end;

class operator TTimeSpan.Add(const Left, Right: TTimeSpan): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class operator TTimeSpan.Add(const Left: TTimeSpan; Right: TDateTime): TDateTime;
begin
  Result := 0;
end;

class operator TTimeSpan.Add(const Left: TDateTime; Right: TTimeSpan): TDateTime;
begin
  Result := 0;
end;

class operator TTimeSpan.Subtract(const Left, Right: TTimeSpan): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class operator TTimeSpan.Subtract(const Left: TDateTime; Right: TTimeSpan): TDateTime;
begin
  Result := 0;
end;

class operator TTimeSpan.Equal(const Left, Right: TTimeSpan): Boolean;
begin
  Result := False;
end;

class operator TTimeSpan.NotEqual(const Left, Right: TTimeSpan): Boolean;
begin
  Result := False;
end;

class operator TTimeSpan.GreaterThan(const Left, Right: TTimeSpan): Boolean;
begin
  Result := False;
end;

class operator TTimeSpan.GreaterThanOrEqual(const Left, Right: TTimeSpan): Boolean;
begin
  Result := False;
end;

class operator TTimeSpan.LessThan(const Left, Right: TTimeSpan): Boolean;
begin
  Result := False;
end;

class operator TTimeSpan.LessThanOrEqual(const Left, Right: TTimeSpan): Boolean;
begin
  Result := False;
end;

class operator TTimeSpan.Negative(const Value: TTimeSpan): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class operator TTimeSpan.Positive(const Value: TTimeSpan): TTimeSpan;
begin
  Result.FTicks := 0;
end;

class operator TTimeSpan.Implicit(const Value: TTimeSpan): string;
begin
  Result := '';
end;

class operator TTimeSpan.Explicit(const Value: TTimeSpan): string;
begin
  Result := '';
end;

function TTimeSpan.GetDays: Integer;
begin
  Result := 0;
end;

function TTimeSpan.GetHours: Integer;
begin
  Result := 0;
end;

function TTimeSpan.GetMinutes: Integer;
begin
  Result := 0;
end;

function TTimeSpan.GetSeconds: Integer;
begin
  Result := 0;
end;

function TTimeSpan.GetMilliseconds: Integer;
begin
  Result := 0;
end;

function TTimeSpan.GetTotalDays: Double;
begin
  Result := 0;
end;

function TTimeSpan.GetTotalHours: Double;
begin
  Result := 0;
end;

function TTimeSpan.GetTotalMinutes: Double;
begin
  Result := 0;
end;

function TTimeSpan.GetTotalSeconds: Double;
begin
  Result := 0;
end;

function TTimeSpan.GetTotalMilliseconds: Double;
begin
  Result := 0;
end;

end.
