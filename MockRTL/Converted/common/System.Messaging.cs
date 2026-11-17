using System;
using static System.Messaging.MessagingImplementation;
using static System.Messaging.MessagingInterface;
using static System.SystemInterface;

namespace System
{

namespace Messaging
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.Messaging.
  This unit provides message types and signatures for source translation.
  It does not dispatch messages or manage subscriptions.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class MessagingInterface
{

	public class TMessageBase : TObject
	{


		public TMessageBase() {}
	}	

  // Generic message whose payload may be a value or reference type.

	public class TMessage<T> : TMessageBase
	{
		private T FValue;
		public TMessage(T AValue)
		{
			;
			FValue = AValue;
		}
		/*property Value : T read FValue;*/
		public T Value
		{
			get
			{
				return FValue;
			}
		}

		public TMessage() {}
	}	

  // A message that can optionally own its object payload.

	public class TObjectMessage<T> : TMessage<T>
		where T: class
	{
		private bool FOwnsObject;
		public TObjectMessage(T AValue, bool AOwnsObject = true)
		:		base(AValue)
		{
			//# base.Create(AValue);
			FOwnsObject = AOwnsObject;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{

  // No ownership handling in the mock.
				base.Destroy();
			}
		}
		/*property OwnsObject : bool read FOwnsObject;*/
		public bool OwnsObject
		{
			get
			{
				return FOwnsObject;
			}
		}

		public TObjectMessage() {}
	}	

	public class TMessageManager : TObject
	{
		private static TMessageManager FDefaultManager;
		private static TMessageManager GetDefaultManager()
		{
			TMessageManager result = default;
  // The mock deliberately does not create a global manager.
			result = FDefaultManager;
			return result;
		}
		public TMessageManager()
		{
			;
		}
		/*property DefaultManager : TMessageManager read GetDefaultManager;*/
		public static TMessageManager DefaultManager
		{
			get
			{
				return GetDefaultManager();
			}
		}
		public virtual int SubscribeToMessage(TClass AMessageClass, TMessageListener AListener)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual int SubscribeToMessage(TClass AMessageClass, TMessageListenerMethod AListenerMethod)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual void Unsubscribe(TClass AMessageClass, int Id, bool Immediate = false)
		{
		}
		public virtual void Unsubscribe(TClass AMessageClass, TMessageListener AListener, bool Immediate = false)
		{
		}
		public virtual void Unsubscribe(TClass AMessageClass, TMessageListenerMethod AListenerMethod, bool Immediate = false)
		{
		}
		public void SendMessage(TObject Sender, TMessageBase AMessage)
		{
		}
		public virtual void SendMessage(TObject Sender, TMessageBase AMessage, bool ADispose)
		{
		}
	}	
  // Base class for messages without a payload.


  // Listener signatures: a method of an object or an anonymous method.
public delegate void TMessageListenerMethod(TObject Sender, TMessageBase M);
public delegate void TMessageListener(TObject Sender, TMessageBase M);
	
} // class MessagingInterface


file class MessagingImplementation
{

} // class MessagingImplementation

}  // namespace Messaging

}  // namespace System

