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

