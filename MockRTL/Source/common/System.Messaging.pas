{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.Messaging.
  This unit provides message types and signatures for source translation.
  It does not dispatch messages or manage subscriptions.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.Messaging;

interface

type
  // Base class for messages without a payload.
  TMessageBase = class(TObject)
  end;

  TMessage = TMessageBase;

  // Generic message whose payload may be a value or reference type.
  TMessage<T> = class(TMessageBase)
  private
    FValue: T;
  public
    constructor Create(const AValue: T);
    property Value: T read FValue;
  end;

  // A message that can optionally own its object payload.
  TObjectMessage<T: class> = class(TMessage<T>)
  private
    FOwnsObject: Boolean;
  public
    constructor Create(const AValue: T; AOwnsObject: Boolean = True);
    destructor Destroy; override;
    property OwnsObject: Boolean read FOwnsObject;
  end;

  // Listener signatures: a method of an object or an anonymous method.
  TMessageListenerMethod = procedure(const Sender: TObject;
    const M: TMessage) of object;
  TMessageListener = reference to procedure(const Sender: TObject;
    const M: TMessage);

  TMessageSubscriptionId = Integer;

  TMessageManager = class(TObject)
  private
    class var FDefaultManager: TMessageManager;
    class function GetDefaultManager: TMessageManager; static;
  public
    constructor Create;
    class property DefaultManager: TMessageManager read GetDefaultManager;

    function SubscribeToMessage(const AMessageClass: TClass;
      const AListener: TMessageListener): TMessageSubscriptionId; overload; virtual;
    function SubscribeToMessage(const AMessageClass: TClass;
      const AListenerMethod: TMessageListenerMethod): TMessageSubscriptionId; overload; virtual;

    procedure Unsubscribe(const AMessageClass: TClass;
      Id: TMessageSubscriptionId; Immediate: Boolean = False); overload; virtual;
    procedure Unsubscribe(const AMessageClass: TClass;
      const AListener: TMessageListener; Immediate: Boolean = False); overload; virtual;
    procedure Unsubscribe(const AMessageClass: TClass;
      const AListenerMethod: TMessageListenerMethod;
      Immediate: Boolean = False); overload; virtual;

    procedure SendMessage(const Sender: TObject; AMessage: TMessage); overload;
    procedure SendMessage(const Sender: TObject; AMessage: TMessage;
      ADispose: Boolean); overload; virtual;
  end;

implementation

constructor TMessage<T>.Create(const AValue: T);
begin
  inherited Create;
  FValue := AValue;
end;

constructor TObjectMessage<T>.Create(const AValue: T;
  AOwnsObject: Boolean);
begin
  inherited Create(AValue);
  FOwnsObject := AOwnsObject;
end;

destructor TObjectMessage<T>.Destroy;
begin
  // No ownership handling in the mock.
  inherited Destroy;
end;

constructor TMessageManager.Create;
begin
  inherited Create;
end;

class function TMessageManager.GetDefaultManager: TMessageManager;
begin
  // The mock deliberately does not create a global manager.
  Result := FDefaultManager;
end;

function TMessageManager.SubscribeToMessage(const AMessageClass: TClass;
  const AListener: TMessageListener): TMessageSubscriptionId;
begin
  Result := 0;
end;

function TMessageManager.SubscribeToMessage(const AMessageClass: TClass;
  const AListenerMethod: TMessageListenerMethod): TMessageSubscriptionId;
begin
  Result := 0;
end;

procedure TMessageManager.Unsubscribe(const AMessageClass: TClass;
  Id: TMessageSubscriptionId; Immediate: Boolean);
begin
end;

procedure TMessageManager.Unsubscribe(const AMessageClass: TClass;
  const AListener: TMessageListener; Immediate: Boolean);
begin
end;

procedure TMessageManager.Unsubscribe(const AMessageClass: TClass;
  const AListenerMethod: TMessageListenerMethod; Immediate: Boolean);
begin
end;

procedure TMessageManager.SendMessage(const Sender: TObject;
  AMessage: TMessage);
begin
end;

procedure TMessageManager.SendMessage(const Sender: TObject;
  AMessage: TMessage; ADispose: Boolean);
begin
end;

end.
