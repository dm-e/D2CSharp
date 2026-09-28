unit vstatic;

interface


type

  a = class(TObject)
  public
    constructor a;

    function prn: String; virtual;
  end;


  b = class(a)
  public
    constructor b;

    function prn: String; override;
  end;

  c = class(b)
  public
    constructor c;

    function prn: String; override;
  end;

  d = class(c)
  public
    constructor d;

    function prn: String; override;
  end;


  TBase = class(TObject)
  public
    procedure Init; virtual;
    procedure Done;
    class function ClassVirtual(xi: Integer): Integer; virtual;
    class function ClassMethod(xi: Integer): Integer;
    class function SecondClassMethod(xi: Integer): Integer;
  end;

  TDerived1 = class(TBase)
  public
    class function ClassVirtual(xi: Integer): Integer; override;
    procedure Init; override;
    procedure Done;
  end;

  TDerived2 = class(TDerived1)
  public
    procedure Init; override;
    procedure Done;
    class function ClassVirtual(xi: Integer): Integer; override;
  end;

  function TestVStatic: boolean;

implementation



var
_result: String;

constructor a.a;
begin
  _result := 'a::a ';
end;

function a.prn: String;
  begin
  result := 'a';
end;


constructor b.b;
begin
  _result :='b::b';
end;

function b.prn(): String;
  begin
  result := 'b';
end;

constructor c.c;
begin
  _result := 'c::c';
end;

function c.prn: String;
  begin
  result := 'c';
end;

constructor d.d;
begin
  _result := 'd::d';
end;

function d.prn: String;
  begin
  result := 'd';
end;


procedure TBase.Init;
begin
  _result := 'TBase.Init';
end;

procedure TBase.Done;
begin
  _result := 'TBase.Done';
end;

class function TBase.ClassMethod(xi: Integer): Integer;
begin
  with Create do
  begin
    Init;
    Done;
    Free;
  end;
  result := xi;
end;

class function TBase.SecondClassMethod(xi: Integer): Integer;
var
  base : TBase;
begin
  ClassMethod(xi);
  ClassVirtual(xi);
  base := TBase.Create;
  base.ClassMethod(0);
  base.Free;
end;


class function TBase.ClassVirtual(xi: Integer): Integer;
begin
  with Create do
  begin
    Init;
    Done;
    Free;
  end;
  result := xi;
end;

///////////  Derived1

procedure TDerived1.Init;
begin
  _result := 'TDerived1.Init';
end;

procedure TDerived1.Done;
begin
  _result := 'TDerived1.Done';
end;

class function TDerived1.ClassVirtual(xi: Integer): Integer;
begin
  with Create do
  begin
    Init;
    Done;
    Free;
  end;
  result := xi;
end;


///////////  Derived2

procedure TDerived2.Init;
begin
  _result := 'TDerived2.Init';
end;

procedure TDerived2.Done;
begin
  _result := 'TDerived2.Done';
end;


class function TDerived2.ClassVirtual(xi: Integer): Integer;
begin
  with Create do
  begin
    Init;
    Done;
    Free;
  end;
  result := xi;
end;

function TestVStatic: boolean;
Var
  pobj : TObject;
  mobj : TClass;
  pa : a;
  ma : TClass;
  pa2 : a;
  ma2 : TClass;
  pb : b;
  mb : TClass;
  pc : c;
  mc : TClass;
  aBase : a;
  p: TBase;
  pBase: TBase;
  pDerived1: TDerived1;
  pDerived2: TDerived2;
  bl : boolean;
  s1, s2 : String;
begin

  result := true;

  pobj := TObject.Create;
	mobj := pobj.ClassType();
  s1 := pobj.ClassName(); // Delphi: 'TObject'; VisualC++: class System::TObject
  s2 := mobj.ClassName();
  result := result and (s1 = s2);

  // compile test: call class method by instance and by class
  pBase := TBase.Create();
  pBase.ClassMethod(0);
  TBase.ClassMethod(0);
  // compile test end


  pa := a.Create;
  ma := pa.ClassType();
  s1 := pa.ClassName();
  s2 := ma.ClassName();
  result := result and (s1 = s2);

  pb := b.Create;
  mb := pb.ClassType();
  s1 := pb.ClassName();
  s2 := mb.ClassName();
  result := result and (s1 = s2);

  pc := c.Create;
  mc := pc.ClassType();
  s1 := pc.ClassName();
  s2 := mc.ClassName();
  result := result and (s1 = s2);

  pa2 := pc;
  ma2 := mc;
  s1 := pa2.ClassName();   // c
  s2 := ma2.ClassName();   // c
  result := result and (s1 = s2);

  s1 := pb.ClassName();
  s2 := mc.ClassName();
  result := result and (s1 <> s2);


  aBase := c.Create;
  s1 := aBase.prn(); // = 'c';

  bl :=  pa.ClassType().InheritsFrom(pobj.ClassType());
  result := result and bl;
  bl :=  pa.ClassType().InheritsFrom(pc.ClassType());
  result := result and not bl;
  bl :=  pc.ClassType().InheritsFrom(pa.ClassType());
  result := result and bl;
  bl :=  pa.InheritsFrom(pc.ClassType());
  result := result and not bl;
  bl :=  pc.InheritsFrom(pa.ClassType());
  result := result and bl;
  bl :=  pa.InheritsFrom(c);
  result := result and not bl;
  bl :=  pc.InheritsFrom(a);
  result := result and bl;

//------

  aBase := pb;
  s1 := aBase.ClassName(); // = 'b'
  mobj := aBase.ClassType();
  s2 := mobj.ClassName(); // = 'b'
  ma := aBase.ClassType();
    result := result and (s1 = s2);


  s1 := ma.ClassName(); // = 'b'
  mB := aBase.ClassType();
  s2 := mb.ClassName(); // = 'b'
  result := result and (s1 = s2);


  pBase := TBase.Create;
  pDerived1 := TDerived1.Create;
  pDerived2 := TDerived2.Create;

  pBase.ClassMethod(0);
  result := result and (_result = 'TBase.Done');
  pDerived1.ClassMethod(1);
  result := result and (_result = 'TBase.Done');
  pDerived2.ClassMethod(2);
  result := result and (_result = 'TBase.Done');

  pBase.ClassVirtual(1);
  result := result and (_result = 'TBase.Done');
  pDerived1.ClassVirtual(1);
  result := result and (_result = 'TDerived1.Done');
  pDerived2.ClassVirtual(2);
  result := result and (_result = 'TDerived2.Done');

  p := pDerived1;
  p.ClassVirtual(1);
  result := result and (_result = 'TDerived1.Done');
  p := pDerived2;
  p.ClassVirtual(2);
  result := result and (_result = 'TDerived2.Done');

  TBase.ClassMethod(0);
  result := result and (_result = 'TBase.Done');
  TDerived1.ClassMethod(1);
  result := result and (_result = 'TBase.Done');
  TDerived2.ClassMethod(2);
  result := result and (_result = 'TBase.Done');
  TBase.ClassVirtual(0);
  result := result and (_result = 'TBase.Done');
  TDerived1.ClassVirtual(1);
  result := result and (_result = 'TDerived1.Done');
  TDerived2.ClassVirtual(2);
  result := result and (_result = 'TDerived2.Done');

  pa.Free;
  pb.Free;
  pc.Free;
  pBase.Free;
  pDerived1.Free;
  pDerived2.Free;
end;

end.

