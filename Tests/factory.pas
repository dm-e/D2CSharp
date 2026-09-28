{
  D2CSharp test file

  Original source language: Delphi (Pascal).
  The corresponding C# files are automatically translated from the
  Delphi source files by D2CSharp.
  This notice is retained unchanged in both versions.
  
  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0  
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




unit factory;


interface

type
  TFBase = class
  public
    function GetName: String; virtual;
  end;

  TFBaseClass = class of TFBase;

  TFDerived1 = class(TFBase)
  public
    function GetName: String; override;
  end;

  TFDerived1Class = class of TFDerived1;

  TFDerived1b = class(TFBase)
  public
    constructor Create(s : String);
    function GetName: String; override;
  private
    FName : String;
  end;

  TFDerived1bClass = class of TFDerived1b;

  TFDerived2 = class(TFDerived1)
  public
    function GetName: String; override;
  private
    FName : String;
  end;


 function testfactory: boolean;

implementation

function TFBase.GetName: String;
begin
  result := 'TFBase';
end;

function TFDerived1.GetName: String;
begin
  result := 'TFDerived1';
end;

function TFDerived1b.GetName: String;
begin
  result := FName;
end;

constructor TFDerived1b.Create(s : String);
begin
  FName := s;
end;

function TFDerived2.GetName: String;
begin
  result := 'TFDerived2';
end;



function make(Base: TFBaseClass): TFBase;
begin
  result := Base.Create;
end;

function TestInheritsFrom: boolean;
var
  b : TFBase;
  d1 : TFDerived1;
  d2 : TFDerived1b;
  d1d : TFDerived2;
  bc : TFBaseClass;
  d1c : TFDerived1Class;
  d2c : TFDerived1bClass;
  cls1, cls2, cls3 : TClass;
  pcls1, pcls2 : TClass;
begin
  b := TFBase.Create;
  d1 := TFDerived1.Create;
  d2 := TFDerived1b.Create('');
  d1d := TFDerived2.Create;
  bc := TFBase;
  d1c := TFDerived1;
  d2c := TFDerived1b;
  result := true;

  cls1 := b.ClassType;
  result := result and  (cls1 = bc);
  cls2 := d1.ClassType;
  result := result and  (cls2 = d1c);
  pcls1 := d1c.ClassParent;
  result := result and  (pcls1 = bc);

  cls3 := d1d.ClassType;
  result := result and  (cls3 = TFDerived2);
  pcls2 := cls3.ClassParent;
  result := result and  (pcls2 = d1c);

  result := result and d1.InheritsFrom(bc);
  result := result and d1c.InheritsFrom(bc);
  result := result and d2.InheritsFrom(bc);
  result := result and d2c.InheritsFrom(bc);
  result := result and not d2.InheritsFrom(d1c);
  result := result and not d2c.InheritsFrom(d1c);

  result := result and d1.InheritsFrom(TFBase);
  result := result and TFDerived1.InheritsFrom(TFBase);
  result := result and d1c.InheritsFrom(TFBase);
  result := result and d2.InheritsFrom(TFBase);
  result := result and d2c.InheritsFrom(TFBase);
  result := result and not d2.InheritsFrom(TFDerived1);
  result := result and not d2c.InheritsFrom(TFDerived1);

  result := result and not b.InheritsFrom(d1c);

  result := result and d1d.InheritsFrom(TFBase);
  result := result and d1d.InheritsFrom(TFDerived1);
  result := result and not d1d.InheritsFrom(TFDerived1b);


end;

function testfactory: boolean;
var
 s : String;
 p : TFBase;
begin
 p := make(TFDerived1);
 result := p.GetName = 'TFDerived1';
 p := make(TFDerived1b);
 result := result and (p.GetName = '');

 result := result and TestInheritsFrom;

end;

end.

