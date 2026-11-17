{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.Diagnostics for D2CSharp.
  Provides the public TStopwatch API without performing time measurements.
  The method bodies return default values and intentionally have no
  runtime stopwatch behavior.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.Diagnostics;

interface

uses
  System.TimeSpan;

type
  TStopwatch = record
  private
    class var FFrequency: Int64;
    class var FIsHighResolution: Boolean;
    FElapsed: Int64;
    FRunning: Boolean;
    FStartTimeStamp: Int64;
    function GetElapsed: TTimeSpan;
    function GetElapsedMilliseconds: Int64;
    function GetElapsedTicks: Int64;
  public
    class function Create: TStopwatch; static;
    class function GetTimeStamp: Int64; static;
    class function StartNew: TStopwatch; static;
    procedure Reset;
    procedure Start;
    procedure Stop;
    property Elapsed: TTimeSpan read GetElapsed;
    property ElapsedMilliseconds: Int64 read GetElapsedMilliseconds;
    property ElapsedTicks: Int64 read GetElapsedTicks;
    property IsRunning: Boolean read FRunning;
    class property Frequency: Int64 read FFrequency;
    class property IsHighResolution: Boolean read FIsHighResolution;
  end;

implementation

function TStopwatch.GetElapsed: TTimeSpan;
begin
  Result := Default(TTimeSpan);
end;

function TStopwatch.GetElapsedMilliseconds: Int64;
begin
  Result := 0;
end;

function TStopwatch.GetElapsedTicks: Int64;
begin
  Result := 0;
end;

class function TStopwatch.Create: TStopwatch;
begin
  Result.FElapsed := 0;
  Result.FRunning := False;
  Result.FStartTimeStamp := 0;
end;

class function TStopwatch.GetTimeStamp: Int64;
begin
  Result := 0;
end;

class function TStopwatch.StartNew: TStopwatch;
begin
  Result := Create;
end;

procedure TStopwatch.Reset;
begin
end;

procedure TStopwatch.Start;
begin
end;

procedure TStopwatch.Stop;
begin
end;

end.
