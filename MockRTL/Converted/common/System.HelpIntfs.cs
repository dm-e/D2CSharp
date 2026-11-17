using System.Classes;
using System.Runtime.InteropServices;
using System.Sysutils;
using System;
using static System.Classes.ClassesInterface;
using static System.Helpintfs.HelpintfsImplementation;
using static System.Helpintfs.HelpintfsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;

namespace System
{

namespace Helpintfs
{

/*
  D2CSharp Runtime Library (RTL)

  Independent declaration-oriented Delphi mock source.
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
*/

/* Declaration-only mock; runtime behavior is implemented in the C# RTL. */


public class HelpintfsInterface
{
	[Guid("B0FC9358-5F0E-11D3-A3B9-00C04F79AD3A")]
	public interface IHelpSelector : IInterface
	{
		int SelectKeyword(TStrings Keywords);
		int TableOfContents(TStrings Contents);
	}	
	[Guid("F65368F4-CA3B-482C-ABD2-3FC23F801D8B")]
	public interface IHelpSelector2 : IHelpSelector
	{
		int SelectContext(TStrings Viewers);
	}	
	[Guid("B0FC9353-5F0E-11D3-A3B9-00C04F79AD3A")]
	public interface IHelpSystem : IInterface
	{
		void ShowHelp(string HelpKeyword, string HelpFileName);
		void ShowContextHelp(int /*# guessed*/ /*-MaxInt..MaxInt*/ ContextID, string HelpFileName);
		void ShowTableOfContents();
		void ShowTopicHelp(string Topic, string HelpFileName);
		void AssignHelpSelector(IHelpSelector Selector);
		bool Hook(ulong Handle, string HelpFile, ushort Comand, long Data);
	}	
	[Guid("48C5336E-71E2-4406-A08E-F915FBA5C9D4")]
	public interface IHelpSystem2 : IHelpSystem
	{
		bool UnderstandsKeyword(string HelpKeyword, string HelpFileName);
	}	
	[Guid("006A65EE-9A5E-4EB1-828F-A7F1D79DD202")]
	public interface IHelpSystem3 : IHelpSystem2
	{
		void ShowIndex(string Topic, string HelpFileName);
		void ShowSearch(string Topic, string HelpFileName);
		void ShowTopicHelp(string Topic, string Anchor, string HelpFileName);
		string GetFilter();
		void SetFilter(string Filter);
	}	
	[Guid("B0FC9364-5F0E-11D3-A3B9-00C04F79AD3A")]
	public interface ICustomHelpViewer : IInterface
	{
		string GetViewerName();
		int UnderstandsKeyword(string HelpString);
		TStringList GetHelpStrings(string HelpString);
		bool CanShowTableOfContents();
		void ShowTableOfContents();
		void ShowHelp(string HelpString);
		void NotifyID(int ViewerID);
		void SoftShutDown();
		void ShutDown();
	}	
	[Guid("B0FC9366-5F0E-11D3-A3B9-00C04F79AD3A")]
	public interface IExtendedHelpViewer : ICustomHelpViewer
	{
		bool UnderstandsTopic(string Topic);
		void DisplayTopic(string Topic);
		bool UnderstandsContext(int /*# guessed*/ /*-MaxInt..MaxInt*/ ContextID, string HelpFileName);
		void DisplayHelpByContext(int /*# guessed*/ /*-MaxInt..MaxInt*/ ContextID, string HelpFileName);
	}	
	[Guid("DD46A379-569A-46AA-89E5-8AACA764304B")]
	public interface IExtendedHelpViewer2 : IExtendedHelpViewer
	{
		void DisplayIndex(string Topic);
		void DisplaySearch(string Topic);
		void DisplayTopic(string Topic, string Anchor);
	}	
	[Guid("991F8E1A-2E3F-4ACB-91A8-4B9587BBA878")]
	public interface IFilteredHelpViewer : IExtendedHelpViewer2
	{
		string GetFilter();
		void SetFilter(string Filter);
	}	
	[Guid("1A7B2224-1EAE-4313-BAD6-3C32F8F77085")]
	public interface ISpecialWinHelpViewer : IExtendedHelpViewer
	{
		bool CallWinHelp(ulong Handle, string HelpFile, ushort Command, ulong Data);
	}	
	[Guid("69418F09-5E49-4899-9E13-9FE3C1497566")]
	public interface IHelpSystemFlags : IExtendedHelpViewer
	{
		bool GetUseDefaultTopic();
		void SetUseDefaultTopic(bool AValue);
	}	
	[Guid("6B0CDB05-C30A-414B-99C4-F11CD195385E")]
	public interface IHelpManager : IInterface
	{
		ulong GetHandle();
		string GetHelpFile();
		void Release(int ViewerID);
	}	

	public class EHelpSystemException : DException
	{


		public EHelpSystemException(string Msg) : base(Msg) {}
		public EHelpSystemException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EHelpSystemException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EHelpSystemException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EHelpSystemException(ulong Ident) : base(Ident) {}
		public EHelpSystemException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EHelpSystemException(ulong Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EHelpSystemException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EHelpSystemException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EHelpSystemException(ulong Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EHelpSystemException(ulong Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EHelpSystemException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	
	public static int RegisterViewer(ICustomHelpViewer newViewer, out IHelpManager Manager)
	{
		Manager = default; //# clear out parameter
		int result = 0;

		Manager = default;
		result = 0;
		return result;
	}
	public static bool GetHelpSystem(out IHelpSystem System)
	{
		System = default; //# clear out parameter
		bool result = false;

		System = default;
		result = false;
		return result;
	}
	public static bool GetHelpSystem(out IHelpSystem2 System)
	{
		System = default; //# clear out parameter
		bool result = false;

		System = default;
		result = false;
		return result;
	}
	public static bool GetHelpSystem(out IHelpSystem3 System)
	{
		System = default; //# clear out parameter
		bool result = false;

		System = default;
		result = false;
		return result;
	}
	
} // class HelpintfsInterface


file class HelpintfsImplementation
{

} // class HelpintfsImplementation

}  // namespace Helpintfs

}  // namespace System

